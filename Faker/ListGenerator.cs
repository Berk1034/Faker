﻿using System;
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

        public ListGenerator(Dictionary<Type, IGenerator> Generators)
        {
            AvailableGenerators = Generators;
        }

        public object Generate(Type listtype)
        {
            IList listinstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listtype));
            int listsize = rnd.Next(1, 21);
            for(int i = 0; i < listsize; i++)
            {
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
        }
    }
}
