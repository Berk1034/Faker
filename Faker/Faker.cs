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
            if (!type.IsAbstract || !type.IsPrimitive)
            {
                ConstructorInfo ConstructorWithMaxArgs = GetConstructorWithMaxParams(type);
                return (T)GenerateObjectFromConstructor(ConstructorWithMaxArgs);
            }
            return default(T);
        }

        private ConstructorInfo GetConstructorWithMaxParams(Type type)
        {
            ConstructorInfo constructorwithmaxparams = null;
            int count = 0;
            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                if(count < constructor.GetParameters().Count())
                {
                    constructorwithmaxparams = constructor;
                    count = constructor.GetParameters().Count();
                }
            }
            return constructorwithmaxparams;
        }

        private object GenerateObjectFromConstructor(ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] parametersValues = new object[parameters.Length];
            for(int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType.IsGenericType)
                {
                    parametersValues[i] = listGenerator.Generate((Type)parameters[i].ParameterType.GenericTypeArguments.GetValue(0));
                }
                else
                {
                    IGenerator valueGenerator;
                    Generators.TryGetValue(parameters[i].ParameterType, out valueGenerator);
                    parametersValues[i] = valueGenerator.Generate();
                }
            }
            
            return constructor.Invoke(parametersValues);
        }
    }
}
