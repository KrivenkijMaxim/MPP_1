using System;
using System.Collections.Generic;
using System.IO;
using SerializationAbstractions;
using System.Reflection;

namespace Serialization
{
    public class PluginLoader
    {
        private const string PluginPath = "../../../../../Tracer.Serialization/Plugins";
        public List<Type> plugins = new List<Type>();
        public void LoadPlugins()
        {
            var files = Directory.GetFiles(PluginPath, "*.dll", SearchOption.TopDirectoryOnly);
            
            foreach (var filePath in files)
            {
                var assembly = Assembly.LoadFrom(filePath);
                var type = assembly.GetExportedTypes()[0];

                if (!type.IsInterface && type.IsAssignableTo(typeof(ITraceResultSerializer)))
                {
                    plugins.Add(type);
                }
            }
        }
    }
}