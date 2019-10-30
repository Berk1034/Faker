using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using IGeneratorLibrary;
using System.IO;

namespace Faker
{
    public class Faker
    {
        public Dictionary<Type, IGenerator> Generators = new Dictionary<Type, IGenerator>();
        public Stack<Type> generationStack;

        public Faker()
        {
            List<Assembly> Plugins = Plugin.LoadPlugin(Path.GetDirectoryName(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName) + Plugin.path + "ByteGenerator.dll");
            Generators = Plugin.GetGenerators(Plugins);
            Generators.Add(typeof(int), new IntGenerator());
            Generators.Add(typeof(bool), new BoolGenerator());
        }

        public T Create<T>()
        {
            foreach(KeyValuePair<Type, IGenerator> generator in Generators){
                if (generator.Key == typeof(T))
                    return (T)generator.Value.Generate();
            }
            return default(T);
        }
    }
}
