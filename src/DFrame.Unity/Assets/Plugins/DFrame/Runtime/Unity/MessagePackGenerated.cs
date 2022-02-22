// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1649 // File name should match first type name

namespace DFrame
{
    using System;

    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        private GeneratedResolver()
        {
        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(7)
            {
                { typeof(global::DFrame.WorkloadParameterInfo[]), 0 },
                { typeof(global::System.Collections.Generic.List<long>), 1 },
                { typeof(global::DFrame.AllowParameterType), 2 },
                { typeof(global::DFrame.BatchedExecuteResult), 3 },
                { typeof(global::DFrame.ExecuteResult), 4 },
                { typeof(global::DFrame.WorkloadInfo), 5 },
                { typeof(global::DFrame.WorkloadParameterInfo), 6 },
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
                case 0: return new global::MessagePack.Formatters.ArrayFormatter<global::DFrame.WorkloadParameterInfo>();
                case 1: return new global::MessagePack.Formatters.ListFormatter<long>();
                case 2: return new MessagePack.Formatters.DFrame.AllowParameterTypeFormatter();
                case 3: return new MessagePack.Formatters.DFrame.BatchedExecuteResultFormatter();
                case 4: return new MessagePack.Formatters.DFrame.ExecuteResultFormatter();
                case 5: return new MessagePack.Formatters.DFrame.WorkloadInfoFormatter();
                case 6: return new MessagePack.Formatters.DFrame.WorkloadParameterInfoFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1649 // File name should match first type name


// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.DFrame
{
    using System;
    using System.Buffers;
    using MessagePack;

    public sealed class AllowParameterTypeFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DFrame.AllowParameterType>
    {
        public void Serialize(ref MessagePackWriter writer, global::DFrame.AllowParameterType value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.Write((Int32)value);
        }

        public global::DFrame.AllowParameterType Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            return (global::DFrame.AllowParameterType)reader.ReadInt32();
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name



// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.DFrame
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class BatchedExecuteResultFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DFrame.BatchedExecuteResult>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DFrame.BatchedExecuteResult value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(2);
            formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadId>().Serialize(ref writer, value.WorkloadId, options);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<long>>().Serialize(ref writer, value.BatchedElapsed, options);
        }

        public global::DFrame.BatchedExecuteResult Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __WorkloadId__ = default(global::DFrame.WorkloadId);
            var __BatchedElapsed__ = default(global::System.Collections.Generic.List<long>);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __WorkloadId__ = formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadId>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        __BatchedElapsed__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<long>>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DFrame.BatchedExecuteResult(__WorkloadId__, __BatchedElapsed__);
            reader.Depth--;
            return ____result;
        }
    }

    public sealed class ExecuteResultFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DFrame.ExecuteResult>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DFrame.ExecuteResult value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(5);
            formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadId>().Serialize(ref writer, value.WorkloadId, options);
            formatterResolver.GetFormatterWithVerify<global::System.TimeSpan>().Serialize(ref writer, value.Elapsed, options);
            writer.Write(value.ExecutionNo);
            writer.Write(value.HasError);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.ErrorMessage, options);
        }

        public global::DFrame.ExecuteResult Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __WorkloadId__ = default(global::DFrame.WorkloadId);
            var __Elapsed__ = default(global::System.TimeSpan);
            var __ExecutionNo__ = default(long);
            var __HasError__ = default(bool);
            var __ErrorMessage__ = default(string);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __WorkloadId__ = formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadId>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        __Elapsed__ = formatterResolver.GetFormatterWithVerify<global::System.TimeSpan>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        __ExecutionNo__ = reader.ReadInt64();
                        break;
                    case 3:
                        __HasError__ = reader.ReadBoolean();
                        break;
                    case 4:
                        __ErrorMessage__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DFrame.ExecuteResult(__WorkloadId__, __Elapsed__, __ExecutionNo__, __HasError__, __ErrorMessage__);
            reader.Depth--;
            return ____result;
        }
    }

    public sealed class WorkloadInfoFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DFrame.WorkloadInfo>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DFrame.WorkloadInfo value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(2);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
            formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadParameterInfo[]>().Serialize(ref writer, value.Arguments, options);
        }

        public global::DFrame.WorkloadInfo Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __Name__ = default(string);
            var __Arguments__ = default(global::DFrame.WorkloadParameterInfo[]);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __Name__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        __Arguments__ = formatterResolver.GetFormatterWithVerify<global::DFrame.WorkloadParameterInfo[]>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DFrame.WorkloadInfo(__Name__, __Arguments__);
            reader.Depth--;
            return ____result;
        }
    }

    public sealed class WorkloadParameterInfoFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DFrame.WorkloadParameterInfo>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DFrame.WorkloadParameterInfo value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(7);
            formatterResolver.GetFormatterWithVerify<global::DFrame.AllowParameterType>().Serialize(ref writer, value.ParameterType, options);
            writer.Write(value.IsNullable);
            writer.Write(value.IsArray);
            formatterResolver.GetFormatterWithVerify<object>().Serialize(ref writer, value.DefaultValue, options);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.ParameterName, options);
            formatterResolver.GetFormatterWithVerify<string[]>().Serialize(ref writer, value.EnumNames, options);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.EnumTypeName, options);
        }

        public global::DFrame.WorkloadParameterInfo Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __ParameterType__ = default(global::DFrame.AllowParameterType);
            var __IsNullable__ = default(bool);
            var __IsArray__ = default(bool);
            var __DefaultValue__ = default(object);
            var __ParameterName__ = default(string);
            var __EnumNames__ = default(string[]);
            var __EnumTypeName__ = default(string);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __ParameterType__ = formatterResolver.GetFormatterWithVerify<global::DFrame.AllowParameterType>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        __IsNullable__ = reader.ReadBoolean();
                        break;
                    case 2:
                        __IsArray__ = reader.ReadBoolean();
                        break;
                    case 3:
                        __DefaultValue__ = formatterResolver.GetFormatterWithVerify<object>().Deserialize(ref reader, options);
                        break;
                    case 4:
                        __ParameterName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 5:
                        __EnumNames__ = formatterResolver.GetFormatterWithVerify<string[]>().Deserialize(ref reader, options);
                        break;
                    case 6:
                        __EnumTypeName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DFrame.WorkloadParameterInfo(__ParameterType__, __IsNullable__, __IsArray__, __DefaultValue__, __ParameterName__, __EnumNames__, __EnumTypeName__);
            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name

