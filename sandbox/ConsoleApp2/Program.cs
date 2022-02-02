﻿// See https://aka.ms/new-console-template for more information
using DFrame;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZLogger;

// args = new[] { "myworkload" };

await Host.CreateDefaultBuilder()
    .ConfigureLogging(x =>
    {
        x.ClearProviders();
        x.AddZLoggerConsole();
    })
    .RunDFrameAsync(args, new DFrameOptions("localhost", 7313));

[Workload("myworkload")]
public class TrialWorkload : Workload
{
    readonly ILogger<TrialWorkload> logger;

    public TrialWorkload(ILogger<TrialWorkload> logger)
    {
        this.logger = logger;
    }

    public override async Task ExecuteAsync(WorkloadContext context)
    {
        await Task.Yield();
        logger.LogInformation("OK:" + context.WorkloadId);
    }
}