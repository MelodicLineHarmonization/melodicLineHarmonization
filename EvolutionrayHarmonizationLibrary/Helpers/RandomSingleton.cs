using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Helpers
{
    public static class RandomSingleton
    {
        private static Random random = new Random(123);

        public static double NextDouble() => random.NextDouble();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue">Inclusive value</param>
        /// <param name="maxValue">Exclusive value</param>
        /// <returns></returns>
        public static int Next(int minValue, int maxValue) => random.Next(minValue, maxValue);
    }
}
