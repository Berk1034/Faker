﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGeneratorLibrary;

namespace FakerLibrary
{
    public class LongGenerator : IGenerator
    {
        public object Generate()
        {
            Random rnd = new Random();
            byte[] bytes = new byte[8];
            rnd.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        public Type GeneratedType()
        {
            return typeof(long);
        }
    }
}
