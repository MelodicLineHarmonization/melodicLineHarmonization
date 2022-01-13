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

        private double? abosolutScore = null;
        public Composition Composition { get; }
        public int PopulationNumber { get; init; }

        public double Score
        { 
            get
            {
                if (score.HasValue)
                    return score.Value;

                (score, abosolutScore, isCorrect) = CalculateValue();
                return score.Value;
            }
        }

        public bool IsCorrect
        {
            get
            {
                if (isCorrect.HasValue)
                    return isCorrect.Value;

                (score, abosolutScore, isCorrect) = CalculateValue();
                return isCorrect.Value;
            }
        }

        public double AbsoluteScore
        {
            get
            {
                if (abosolutScore.HasValue)
                    return abosolutScore.Value;

                (score, abosolutScore, isCorrect) = CalculateValue();
                return abosolutScore.Value;
            }
        }

        public CompositionUnit(Composition composition, int populationNumber)
        {
            Composition = composition;
            PopulationNumber = populationNumber;
        }

        public void RecalculateScore()
        {
            (score, abosolutScore, isCorrect) = CalculateValue();
        }

        private (double, double, bool) CalculateValue()
        {
            return GoalFunction.CalculateCompositionScore(Composition, PopulationNumber);
        }


        
    }
}
