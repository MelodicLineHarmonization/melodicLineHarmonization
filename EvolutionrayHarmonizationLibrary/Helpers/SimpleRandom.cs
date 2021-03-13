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
        private readonly Random random;
        public SimpleRandom(Random random)
        {
            this.random = random;
        }

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
