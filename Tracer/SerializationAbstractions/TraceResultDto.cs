using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Concurrent;
using System.Runtime.Serialization;

namespace SerializationAbstractions
{
    [KnownType(typeof(TraceResultDto))]
    [DataContract, Serializable]
    public class TraceResultDto
    {
        [DataMember(Name = "threads")]
        public ConcurrentDictionary<int, ThreadTraceResultDto> ThreadsTraceResult;

        public TraceResultDto(ConcurrentDictionary<int, ThreadTraceResultDto> threads)
        {
            ThreadsTraceResult = threads;
        }
    }
}