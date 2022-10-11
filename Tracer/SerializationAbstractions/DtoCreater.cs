using System.Collections.Concurrent;
using System.Collections.Generic;
using Core;


namespace SerializationAbstractions
{
    public static class DtoCreator
    {
        public static TraceResultDto CreateTraceResultDto(TraceResult traceResult)
        {
            return new TraceResultDto(AddThreadTraceResultsDto(traceResult.ThreadsTraceResult));
        }


        private static ConcurrentDictionary<int, ThreadTraceResultDto> AddThreadTraceResultsDto(
            IReadOnlyDictionary<int, ThreadTraceResult> threadResults)
        {
            var threads = new ConcurrentDictionary<int, ThreadTraceResultDto>();
            foreach (var threadKey in threadResults.Keys)
            {
                threads.GetOrAdd(threadKey, new ThreadTraceResultDto(
                    AddMethodTraceResultDto(threadResults[threadKey].MethodsList),
                    threadResults[threadKey].Elapsed));
            }

            return threads;
        }

        private static List<MethodTraceResultDto> AddMethodTraceResultDto(IReadOnlyList<MethodTraceResult> methodList)
        {
            var methodResultDtoList = new List<MethodTraceResultDto>();
            foreach (var methodResult in methodList)
            {
                var nestedMethodResultDtoList = new List<MethodTraceResultDto>();
                if (methodResult.ChildMethods.Count != 0)
                {
                    nestedMethodResultDtoList = AddMethodTraceResultDto(methodResult.ChildMethods);
                }

                methodResultDtoList.Add(new MethodTraceResultDto(
                        methodResult.ClassName,
                        methodResult.MethodName,
                        methodResult.Elapsed,
                        nestedMethodResultDtoList
                    )
                );
            }

            return methodResultDtoList;
        }
    }
}