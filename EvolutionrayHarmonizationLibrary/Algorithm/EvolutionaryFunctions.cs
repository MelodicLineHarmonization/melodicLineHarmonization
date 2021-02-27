using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm
{
    public static class EvolutionaryFunctions
    {        
        /// <summary>
        /// Mutacja klasyczna - szansa na mutację każdego akordu wynosi 1/(długość kompozycji).
        /// Mutacja akordu - jeden dźwięk zmieniany na inny, całkowicie losowy.
        /// </summary>
        /// <param name="composition"></param>
        public static void MutateComposition(Composition composition)
        {
            int compositionLength = composition.Functions.Count;
            double mutationProbability = 1.0 / compositionLength;

            for (int i = 0; i < compositionLength; i++)
                if (RandomSingleton.NextDouble() <= mutationProbability)
                {
                    int noteToModifyIndex = RandomSingleton.Next(1, 4);
                    composition.MelodicLines[noteToModifyIndex].SetPitch(i, Pitch.GetRandom(0, 7));
                }
        }

        /// <summary>
        /// Krzyżowanie klasyczne - kompozycje krzyżowane są pionowo (podmiany akordów)
        /// </summary>
        /// <param name="composition1"></param>
        /// <param name="composition2"></param>
        public static Composition CrossoverCompositionsVerticaly(Composition composition1, Composition composition2)
        {
            int compositionLength = composition1.Functions.Count;
            Composition childComposition = composition1.Copy();

            for (int i = 0; i < compositionLength; i++)
            {
                int randComposition = RandomSingleton.Next(0, 2);

                if (randComposition == 1)
                    for (int j = 0; j < childComposition.MelodicLines.Count; j++)
                        if (childComposition.MelodicLines[j].IsModifiable)
                            childComposition.MelodicLines[j].SetPitch(i, composition2.MelodicLines[j].GetPitch(i).Copy());
            }

            return childComposition;
        }

        public static void CompositionSelection(List<Composition> population, Func<Composition, int> goalFunction)
        {
            throw new NotImplementedException();
        }
    }
}
