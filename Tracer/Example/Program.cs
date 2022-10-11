using System;
using System.IO;
using Core;
using Serialization;
using SerializationAbstractions;


namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginLoader pluginLoader = new PluginLoader();
            pluginLoader.LoadPlugins();

            ITracer tracer = new Tracer();

            TestClass test = new TestClass(tracer);
            test.StartTest();

                        
            foreach (Type type in pluginLoader.plugins)
            {
                var obj = Activator.CreateInstance(type!) as ITraceResultSerializer;

                obj?.Serialize(tracer.GetTraceResult(),
                    new FileStream("../../../test/result." + obj.Format, FileMode.Create));
            }
        }
    }
}