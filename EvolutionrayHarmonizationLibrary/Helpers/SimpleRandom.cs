using EvolutionrayHarmonizationLibrary.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Helpers
{
    public class SimpleRandom : IRandom
    {
        private readonly int seed;
        private readonly Random random;
        public SimpleRandom(int seed)
        {
            this.seed = seed;
            this.random = new Random(seed);
        }

        public int GetSeed() => seed;

        public double NextDouble() => random.NextDouble();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue">Inclusive value</param>
        /// <param name="maxValue">Exclusive value</param>
        /// <returns></returns>
        public int Next(int minValue, int maxValue) => random.Next(minValue, maxValue);
    }
}
