using System.Threading;
using Core;


namespace Example
{
    public class TestClass
    {
        private ITracer _tracer;

        public TestClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void StartTest()
        {

            Thread thread1 = new Thread(Method1);
            Thread thread2 = new Thread(Method2);
            Thread thread3 = new Thread(Method5);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

        }

        public void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            Method2();
            _tracer.StopTrace();
        }

        public void Method2()
        {
            Method3();
            Thread.Sleep(100);
        }

        public void Method3()
        {
            _tracer.StartTrace();
            Method4(); 
            _tracer.StopTrace();
        }

        public void Method4()
        {
            _tracer.StartTrace();
            Thread.Sleep(400);
            Method5();
            _tracer.StopTrace();
        }

        public void Method5()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }

        public void Method6()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            Method7();
            _tracer.StopTrace();
        }

        public void Method7()
        {
            _tracer.StartTrace();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }

        public void Method8()
        {
            Method6();
            Thread.Sleep(100);
            Method6();
        }

    }
}