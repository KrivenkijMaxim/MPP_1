using System.IO;
using Core;

namespace SerializationAbstractions
{
    public interface ITraceResultSerializer
    {
        string Format { get; }
        void Serialize(TraceResult traceResult, Stream to);
    }
}