// <auto-generated />
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace DFrame
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::MagicOnion;
    using global::MagicOnion.Client;

    public static partial class MagicOnionInitializer
    {
        static bool isRegistered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(isRegistered) return;
            isRegistered = true;


            StreamingHubClientRegistry<DFrame.IControllerHub, DFrame.IWorkerReceiver>.Register((a, _, b, c, d, e) => new DFrame.ControllerHubClient(a, b, c, d, e));
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace DFrame.Resolvers
{
    using System;
    using MessagePack;

    public class MagicOnionResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new MagicOnionResolver();

        MagicOnionResolver()
        {

        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                var f = MagicOnionResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class MagicOnionResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static MagicOnionResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(6)
            {
                {typeof(global::DFrame.WorkloadInfo[]), 0 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::DFrame.ExecutionId, int, string, global::System.Collections.Generic.KeyValuePair<string, string>[]>), 1 },
                {typeof(global::MagicOnion.DynamicArgumentTuple<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>), 2 },
                {typeof(global::System.Collections.Generic.Dictionary<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>>), 3 },
                {typeof(global::System.Collections.Generic.Dictionary<string, string>), 4 },
                {typeof(global::System.Collections.Generic.KeyValuePair<string, string>[]), 5 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new global::MessagePack.Formatters.ArrayFormatter<global::DFrame.WorkloadInfo>();
                case 1: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::DFrame.ExecutionId, int, string, global::System.Collections.Generic.KeyValuePair<string, string>[]>(default(global::DFrame.ExecutionId), default(int), default(string), default(global::System.Collections.Generic.KeyValuePair<string, string>[]));
                case 2: return new global::MagicOnion.DynamicArgumentTupleFormatter<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>(default(global::DFrame.WorkloadInfo[]), default(global::System.Collections.Generic.Dictionary<string, string>));
                case 3: return new global::MessagePack.Formatters.DictionaryFormatter<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>>();
                case 4: return new global::MessagePack.Formatters.DictionaryFormatter<string, string>();
                case 5: return new global::MessagePack.Formatters.ArrayFormatter<global::System.Collections.Generic.KeyValuePair<string, string>>();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 612
#pragma warning restore 618
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace DFrame {
    using Grpc.Core;
    using MagicOnion;
    using MagicOnion.Client;
    using MessagePack;
    using System;
    using System.Threading.Tasks;

    [Ignore]
    public class ControllerHubClient : StreamingHubClientBase<global::DFrame.IControllerHub, global::DFrame.IWorkerReceiver>, global::DFrame.IControllerHub
    {
        static readonly Method<byte[], byte[]> method = new Method<byte[], byte[]>(MethodType.DuplexStreaming, "IControllerHub", "Connect", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);

        protected override Method<byte[], byte[]> DuplexStreamingAsyncMethod { get { return method; } }

        readonly global::DFrame.IControllerHub __fireAndForgetClient;

        public ControllerHubClient(CallInvoker callInvoker, string host, CallOptions option, MessagePackSerializerOptions serializerOptions, IMagicOnionClientLogger logger)
            : base(callInvoker, host, option, serializerOptions, logger)
        {
            this.__fireAndForgetClient = new FireAndForgetClient(this);
        }
        
        public global::DFrame.IControllerHub FireAndForget()
        {
            return __fireAndForgetClient;
        }

        protected override void OnBroadcastEvent(int methodId, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case 984740550: // CreateWorkloadAndSetup
                {
                    var result = MessagePackSerializer.Deserialize<DynamicArgumentTuple<global::DFrame.ExecutionId, int, string, global::System.Collections.Generic.KeyValuePair<string, string>[]>>(data, serializerOptions);
                    receiver.CreateWorkloadAndSetup(result.Item1, result.Item2, result.Item3, result.Item4); break;
                }
                case 650159416: // Execute
                {
                    var result = MessagePackSerializer.Deserialize<long[]>(data, serializerOptions);
                    receiver.Execute(result); break;
                }
                case 1266644741: // Stop
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    receiver.Stop(); break;
                }
                case -9051375: // Teardown
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    receiver.Teardown(); break;
                }
                default:
                    break;
            }
        }

        protected override void OnResponseEvent(int methodId, object taskCompletionSource, ArraySegment<byte> data)
        {
            switch (methodId)
            {
                case 2012341859: // ConnectAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -933234259: // CreateWorkloadCompleteAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -2138341752: // ReportProgressAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 1635120551: // ReportProgressBatchedAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case 244451313: // ExecuteCompleteAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                case -1034933934: // TeardownCompleteAsync
                {
                    var result = MessagePackSerializer.Deserialize<Nil>(data, serializerOptions);
                    ((TaskCompletionSource<Nil>)taskCompletionSource).TrySetResult(result);
                    break;
                }
                default:
                    break;
            }
        }
   
        public global::System.Threading.Tasks.Task ConnectAsync(global::DFrame.WorkloadInfo[] workloads, global::System.Collections.Generic.Dictionary<string, string> metadata)
        {
            return WriteMessageWithResponseAsync<DynamicArgumentTuple<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>, Nil>(2012341859, new DynamicArgumentTuple<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>(workloads, metadata));
        }

        public global::System.Threading.Tasks.Task CreateWorkloadCompleteAsync(global::DFrame.ExecutionId executionId)
        {
            return WriteMessageWithResponseAsync<global::DFrame.ExecutionId, Nil>(-933234259, executionId);
        }

        public global::System.Threading.Tasks.Task ReportProgressAsync(global::DFrame.ExecuteResult result)
        {
            return WriteMessageWithResponseAsync<global::DFrame.ExecuteResult, Nil>(-2138341752, result);
        }

        public global::System.Threading.Tasks.Task ReportProgressBatchedAsync(global::DFrame.BatchedExecuteResult result)
        {
            return WriteMessageWithResponseAsync<global::DFrame.BatchedExecuteResult, Nil>(1635120551, result);
        }

        public global::System.Threading.Tasks.Task ExecuteCompleteAsync(global::System.Collections.Generic.Dictionary<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>> results)
        {
            return WriteMessageWithResponseAsync<global::System.Collections.Generic.Dictionary<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>>, Nil>(244451313, results);
        }

        public global::System.Threading.Tasks.Task TeardownCompleteAsync()
        {
            return WriteMessageWithResponseAsync<Nil, Nil>(-1034933934, Nil.Default);
        }


        class FireAndForgetClient : global::DFrame.IControllerHub
        {
            readonly ControllerHubClient __parent;

            public FireAndForgetClient(ControllerHubClient parentClient)
            {
                this.__parent = parentClient;
            }

            public global::DFrame.IControllerHub FireAndForget()
            {
                throw new NotSupportedException();
            }

            public Task DisposeAsync()
            {
                throw new NotSupportedException();
            }

            public Task WaitForDisconnect()
            {
                throw new NotSupportedException();
            }

            public global::System.Threading.Tasks.Task ConnectAsync(global::DFrame.WorkloadInfo[] workloads, global::System.Collections.Generic.Dictionary<string, string> metadata)
            {
                return __parent.WriteMessageAsync<DynamicArgumentTuple<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>>(2012341859, new DynamicArgumentTuple<global::DFrame.WorkloadInfo[], global::System.Collections.Generic.Dictionary<string, string>>(workloads, metadata));
            }

            public global::System.Threading.Tasks.Task CreateWorkloadCompleteAsync(global::DFrame.ExecutionId executionId)
            {
                return __parent.WriteMessageAsync<global::DFrame.ExecutionId>(-933234259, executionId);
            }

            public global::System.Threading.Tasks.Task ReportProgressAsync(global::DFrame.ExecuteResult result)
            {
                return __parent.WriteMessageAsync<global::DFrame.ExecuteResult>(-2138341752, result);
            }

            public global::System.Threading.Tasks.Task ReportProgressBatchedAsync(global::DFrame.BatchedExecuteResult result)
            {
                return __parent.WriteMessageAsync<global::DFrame.BatchedExecuteResult>(1635120551, result);
            }

            public global::System.Threading.Tasks.Task ExecuteCompleteAsync(global::System.Collections.Generic.Dictionary<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>> results)
            {
                return __parent.WriteMessageAsync<global::System.Collections.Generic.Dictionary<global::DFrame.WorkloadId, global::System.Collections.Generic.Dictionary<string, string>>>(244451313, results);
            }

            public global::System.Threading.Tasks.Task TeardownCompleteAsync()
            {
                return __parent.WriteMessageAsync<Nil>(-1034933934, Nil.Default);
            }

        }
    }
}

#pragma warning restore 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
