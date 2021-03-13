using EvolutionrayHarmonizationLibrary.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    public class CompositionUnit
    {


        private double? score = null;
        public Composition Composition { get; }
        public int PopulationNumber { get; init; }

        public double Score
        { 
            get
            {
                if (score.HasValue)
                    return score.Value;

                score = CalculateValue();
                return score.Value;
            }
        }

        public CompositionUnit(Composition composition, int populationNumber)
        {
            Composition = composition;
            PopulationNumber = populationNumber;
        }

        public void RecalculateScore()
        {
            score = CalculateValue();
        }

        private double CalculateValue()
        {
            throw new NotImplementedException();
        }


        
    }
}
