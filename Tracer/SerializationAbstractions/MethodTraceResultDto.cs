using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationAbstractions
{
    [DataContract, Serializable]
    public class MethodTraceResultDto
    {
        [DataMember(Name = "class", Order = 0)]
        public string ClassName { get; set; }

        [DataMember(Name = "method", Order = 1)]
        public string MethodName { get; set; }

        [DataMember(Name = "elapsed", Order = 2)]
        public long Elapsed { get; set; }

        [DataMember(Name = "childs", Order = 3)]
        public List<MethodTraceResultDto>? ChildMethods { get; set; }

        public MethodTraceResultDto(string className, string methodName, long elapsed, List<MethodTraceResultDto> childs)
        {
            ClassName = className;
            MethodName = methodName;
            Elapsed = elapsed;
            ChildMethods = childs;
        }
    }
}