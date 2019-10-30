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
        public ListGenerator listGenerator;

        public Faker()
        {
            List<Assembly> Plugins = Plugin.LoadPlugin(Path.GetDirectoryName(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName) + Plugin.path + "ByteGenerator.dll", Path.GetDirectoryName(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName) + Plugin.path + "FloatGenerator.dll");
            Generators = Plugin.GetGenerators(Plugins);
            Generators.Add(typeof(int), new IntGenerator());
            Generators.Add(typeof(bool), new BoolGenerator());
            Generators.Add(typeof(DateTime), new DateTimeGenerator());
            Generators.Add(typeof(char), new CharGenerator());
            Generators.Add(typeof(double), new DoubleGenerator());
            Generators.Add(typeof(long), new LongGenerator());
            Generators.Add(typeof(string), new StringGenerator());
            listGenerator = new ListGenerator(Generators);
        }

        public T Create<T>()
        {
            Type type = typeof(T);
            if(type.IsAbstract || type.IsInterface || type == typeof(void))
            {
                return default(T);
            }
            if (type.IsGenericType)
            {
                return (T)listGenerator.Generate((Type)type.GenericTypeArguments.GetValue(0));
            }
            IGenerator value;
            Generators.TryGetValue(type, out value);
            if(value!= null)
            {
                return (T)value.Generate();
            }
            else
            {
                return default(T);
            }
            /*
            foreach(KeyValuePair<Type, IGenerator> generator in Generators){
                if (generator.Key == typeof(T))
                    return (T)generator.Value.Generate();
            }
            */
        }
    }
}
