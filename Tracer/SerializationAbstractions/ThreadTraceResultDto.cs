using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationAbstractions
{
    [DataContract, Serializable]
    public class ThreadTraceResultDto
    {
        [DataMember(Name = "elapsed", Order = 0)]
        public long Elapsed { get; set; }

        [DataMember(Name = "methods", Order = 1)]
        public List<MethodTraceResultDto> methodsList;

        public ThreadTraceResultDto(List<MethodTraceResultDto> methods, long elapsed)
        {
            methodsList = methods;
            Elapsed = elapsed;  
        }
    }
}