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

        public double AbsoluteMean { get; set; }

        public double AbsoluteStandardDeviation { get; set; }

        public int IterationNumber { get; set; }

        public double MaxValue { get; set; }

        public double AbsoluteMaxValue { get; set; }

        public bool IsMaxCorrect { get; set; }

        public double CorrectUnitsPrecentage { get; set; }

        public int CountOfBest { get; set; }

        public List<Composition> BestCompositions { get; set; }
    }
}
