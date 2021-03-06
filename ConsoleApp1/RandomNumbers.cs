﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class RandomNumbers
    {
        private static System.Random r;

        internal static int NextNumber()
        {
            if (r == null)
                Seed();

            return r.Next();
        }

        internal static int NextNumber(int ceiling)
        {
            if (r == null)
                Seed();

            return r.Next(ceiling);
        }

        internal static void Seed()
        {
            r = new System.Random();
        }

        internal static void Seed(int seed)
        {
            r = new System.Random(seed);
        }
    }
}
