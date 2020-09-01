﻿using ConsoleAppFramework;
using DFrame.Collections;
using DFrame.Internal;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnion.Hosting;
using MagicOnion.Server;
using MessagePack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using ZLogger;

namespace DFrame
{
    public static class DFrameAppHostBuilderExtensions
    {
        public static async Task RunDFrameAsync(this IHostBuilder hostBuilder, string[] args, DFrameOptions options)
        {
            var workerCollection = DFrameWorkerCollection.FromCurrentAssemblies();

            if (args.Length == 0)
            {
                ShowDFrameAppList(workerCollection);
                return;
            }

            hostBuilder = hostBuilder
                .ConfigureServices(x =>
                {
                    x.AddSingleton(options);
                    x.AddSingleton(workerCollection);

                    foreach (var item in workerCollection.All)
                    {
                        x.AddTransient(item.WorkerType);
                    }
                });

            if (args.Length != 0 && args.Contains("--worker-flag"))
            {
                await hostBuilder.RunConsoleAppFrameworkAsync<DFrameWorkerApp>(args);
            }
            else
            {
                await hostBuilder.RunConsoleAppFrameworkAsync<DFrameApp>(args);
            }
        }

        static void ShowDFrameAppList(DFrameWorkerCollection types)
        {
            Console.WriteLine("WorkerNames:");
            foreach (var item in types.All)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    internal class DFrameApp : ConsoleAppBase
    {
        readonly ILogger<DFrameApp> logger;
        readonly IServiceProvider provider;
        readonly DFrameOptions options;
        readonly DFrameWorkerCollection workers;

        public DFrameApp(ILogger<DFrameApp> logger, IServiceProvider provider, DFrameOptions options, DFrameWorkerCollection workers)
        {
            this.provider = provider;
            this.logger = logger;
            this.workers = workers;
            this.options = options;
        }

        [Command("batch")]
        public Task ExecuteAsBatch(
            string workerName,
            int processCount = 1)
        {
            return ExecuteAsConcurrentRequest(workerName, processCount, 1, 1);
        }

        [Command("request")]
        public Task ExecuteAsConcurrentRequest(
            string workerName,
            int processCount,
            int workerPerProcess,
            int executePerWorker)
        {
            return new DFrameConcurrentRequestRunner(logger, provider, options, workers, workerPerProcess, executePerWorker).RunAsync(workerName, processCount, workerPerProcess, executePerWorker, this.Context);
        }

        [Command("rampup")]
        public Task ExecuteAsRampup(
            string workerName,
            int processCount,
            int maxWorkerPerProcess,
            int workerSpawnCount,
            int workerSpawnSecond
            )
        {
            return new DFrameRamupRunner(logger, provider, options, workers, maxWorkerPerProcess, workerSpawnCount, workerSpawnSecond).RunAsync(workerName, processCount, maxWorkerPerProcess, maxWorkerPerProcess, this.Context);
        }
    }

    internal class DFrameWorkerApp : ConsoleAppBase
    {
        ILogger<DFrameWorkerApp> logger;
        IServiceProvider provider;
        DFrameOptions options;

        public DFrameWorkerApp(ILogger<DFrameWorkerApp> logger, IServiceProvider provider, DFrameOptions options)
        {
            this.provider = provider;
            this.logger = logger;
            this.options = options;
        }

        public async Task Main()
        {
            logger.LogInformation("Starting DFrame worker node");

            var channel = new Channel(options.WorkerConnectToHost, options.WorkerConnectToPort, ChannelCredentials.Insecure,
                new[] {
                    // keep alive
                    new ChannelOption("grpc.keepalive_time_ms", 2000),
                    new ChannelOption("grpc.keepalive_timeout_ms", 3000),
                    new ChannelOption("grpc.http2.min_time_between_pings_ms", 5000),
                });
            var nodeId = Guid.NewGuid();
            var receiver = new WorkerReceiver(channel, nodeId, provider, options);
            var callOption = new CallOptions(new Metadata { { "node-id", nodeId.ToString() } });
            var client = StreamingHubClient.Connect<IMasterHub, IWorkerReceiver>(channel, receiver, option: callOption, serializerOptions: options.SerializerOptions);
            receiver.Client = client;

            logger.LogInformation($"Worker -> Master connect successfully, WorkerNodeId:{nodeId.ToString()}.");
            try
            {
                // wait for shutdown command from master.
                await Task.WhenAny(receiver.WaitShutdown.WithCancellation(Context.CancellationToken), client.WaitForDisconnect());
            }
            finally
            {
                await ShutdownAsync(client, channel, nodeId);
            }
        }

        async Task ShutdownAsync(IMasterHub client, Channel channel, Guid nodeId)
        {
            logger.LogInformation($"Worker shutdown, WorkerNodeId:{nodeId.ToString()}.");

            logger.LogTrace($"Worker StreamingHubClient disposing.");
            await client.DisposeAsync();

            logger.LogTrace($"Worker Channel shutdown.");
            await channel.ShutdownAsync();
        }
    }
}