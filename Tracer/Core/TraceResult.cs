using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core
{

    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadTraceResult> _threadsTraceResult;

        public IReadOnlyDictionary<int, ThreadTraceResult> ThreadsTraceResult
        {
            get { return _threadsTraceResult; }
        }

        internal TraceResult()
        {
            _threadsTraceResult = new ConcurrentDictionary<int, ThreadTraceResult>();
        }

        internal ThreadTraceResult GetOrAddThread(int threadId)
        {
            return _threadsTraceResult.GetOrAdd(threadId, new ThreadTraceResult(threadId));
        }
    }
}