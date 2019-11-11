using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace Faker
{
    public class ListGenerator : IListGenerator
    {
        private Dictionary<Type, IGenerator> AvailableGenerators = new Dictionary<Type, IGenerator>();
        private Random rnd = new Random();
        private Faker CurrentFaker;

        public ListGenerator(Dictionary<Type, IGenerator> Generators,Faker MainFaker)
        {
            AvailableGenerators = Generators;
            CurrentFaker = MainFaker;
        }

        public object Generate(Type type)
        {
            IList listinstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            int listsize = rnd.Next(1, 21);
            for(int i = 0; i < listsize; i++)
            {
                listinstance.Add(CurrentFaker.Create(type));
            }
            return listinstance;
            /*
            int listsize = rnd.Next(1, 21);
            List<T> listinstance = new List<T>();
            for(int i = 0; i < listsize; i++)
            {
                listinstance.Add(CurrentFaker.Create<T>());
            }
            return listinstance;
            /*
            IList listinstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listtype));
            int listsize = rnd.Next(1, 21);
            for(int i = 0; i < listsize; i++)
            {
                listinstance.Add(CurrentFaker.Create<listtype>());
                /*
                IGenerator value;
                AvailableGenerators.TryGetValue(listtype, out value);
                if (value != null)
                {
                    listinstance.Add(value.Generate());
                }
                else
                {
                    listinstance.Add(null);
                }
                
            }
            return listinstance;
            */

        }
    }
}
