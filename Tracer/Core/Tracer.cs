using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Core
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;

        public Tracer()
        {
            _traceResult = new TraceResult();

        }
        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public void StartTrace()
        {
            var threadTraceResult = _traceResult.GetOrAddThread(Thread.CurrentThread.ManagedThreadId);

            StackTrace stackTrace = new StackTrace();     // ?????стек для последовательности вызовов методов для трассировки?????

            var method = stackTrace.GetFrame(1).GetMethod(); //????????????????????
            string stackState = string.Join(" ", stackTrace.ToString().Split( ///???????????????????
                new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1));

            threadTraceResult.Current = new MethodTraceResult(method.ReflectedType.Name, method.Name, stackState,
                threadTraceResult.Current);

            threadTraceResult.AddMethod(threadTraceResult.Current);
        }

        public void StopTrace()
        {
            var threadTraceResult = _traceResult.GetOrAddThread(Thread.CurrentThread.ManagedThreadId);

            StackTrace stackTrace = new StackTrace();

            string stackState = string.Join(" ", stackTrace.ToString().Split(
                new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1));

            threadTraceResult.CreateTreeNode(stackState);
        }
    }
}