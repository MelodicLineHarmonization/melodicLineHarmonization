using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    public struct PopulationStatistics
    {
        public double Mean { get; set; }

        public double StandardDeviation { get; set; }

        public double AbsoulteMean { get; set; }

        public double AbsoulteStandardDeviation { get; set; }

        public int IterationNumber { get; set; }

        public double MaxValue { get; set; }

        public double AbsoluteMaxValue { get; set; }

        public bool IsMaxCorrect { get; set; }

        public double CorrectUnitsPrecentage { get; set; }

        public Composition BestComposition { get; set; }
    }
}
