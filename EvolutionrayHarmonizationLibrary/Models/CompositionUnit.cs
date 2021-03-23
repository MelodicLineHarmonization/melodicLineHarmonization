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

        private bool? isCorrect = null;
        public Composition Composition { get; }
        public int PopulationNumber { get; init; }

        public double Score
        { 
            get
            {
                if (score.HasValue)
                    return score.Value;

                (score, isCorrect) = CalculateValue();
                return score.Value;
            }
        }

        public bool IsCorrect
        {
            get
            {
                if (isCorrect.HasValue)
                    return isCorrect.Value;

                (score, isCorrect) = CalculateValue();
                return isCorrect.Value;
            }
        }

        public CompositionUnit(Composition composition, int populationNumber)
        {
            Composition = composition;
            PopulationNumber = populationNumber;
        }

        public void RecalculateScore()
        {
            (score, isCorrect) = CalculateValue();
        }

        private (double, bool) CalculateValue()
        {
            return GoalFunction.CalculateCompositionScore(Composition, PopulationNumber);
        }


        
    }
}
