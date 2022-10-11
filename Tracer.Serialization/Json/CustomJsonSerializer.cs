using Core;
using SerializationAbstractions;
//using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Text;

namespace Json
{
    public class CustomJsonSerializer : ITraceResultSerializer
    {
        private readonly DataContractJsonSerializer _jsonFormatter;

        public CustomJsonSerializer()
        {
            _jsonFormatter = new DataContractJsonSerializer(typeof(TraceResult));
        }

        public string Format => "json";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            using var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(to, Encoding.UTF8, ownsStream: true,
                indent: true, indentChars: "     ");
            _jsonFormatter.WriteObject(jsonWriter, DtoCreator.CreateTraceResultDto(traceResult));
        }
    }
}