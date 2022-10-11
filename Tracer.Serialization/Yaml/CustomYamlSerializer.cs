using Core;
using SerializationAbstractions;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Yaml
{
    public class CustomYamlSerializer : ITraceResultSerializer
    {
        [YamlIgnore]
        private readonly ISerializer _serializer;

        public CustomYamlSerializer()
        {
            _serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public string Format => "yaml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var yamlString = _serializer.Serialize(DtoCreator.CreateTraceResultDto(traceResult));
            using var streamWriter = new StreamWriter(to);
            streamWriter.WriteLine(yamlString);
        }
    }
}