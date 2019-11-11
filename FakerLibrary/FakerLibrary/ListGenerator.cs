using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FakerLibrary
{
    public class ListGenerator : IListGenerator
    {
        private Dictionary<Type, IGenerator> AvailableGenerators = new Dictionary<Type, IGenerator>();
        private Random rnd = new Random();
        private Faker MainFaker;

        public ListGenerator(Faker faker)
        {
            MainFaker = faker;
        }

        public object Generate(Type listtype)
        {
            IList listinstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listtype));
            int listsize = rnd.Next(1, 21);
            for (int i = 0; i < listsize; i++)
            {
                listinstance.Add(MainFaker.Create(listtype));
            }
            return listinstance;
        }
    }
}
