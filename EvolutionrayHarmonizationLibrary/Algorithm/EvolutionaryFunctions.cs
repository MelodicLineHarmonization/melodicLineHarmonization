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
            double mutationProbability = 1.0 / composition.Length;

            for (int i = 0; i < composition.Length; i++)
                if (RandomSingleton.NextDouble() <= mutationProbability)
                {
                    int noteToModifyIndex = RandomSingleton.Next(1, 4);
                    composition.MelodicLines[noteToModifyIndex].SetPitch(i, Pitch.GetRandom(0, 7));
                }
        }

        /// <summary>
        /// Krzyżowanie klasyczne - krzyżowanie następuje dźwiękami (pojedynczy dźwięk może zostać podmieniony)
        /// </summary>
        /// <param name="composition1"></param>
        /// <param name="composition2"></param>
        public static Composition CrossoverCompositions(Composition composition1, Composition composition2)
        {
            Composition childComposition = composition1.Copy();

            for (int i = 0; i < childComposition.MelodicLines.Count; i++)
                if (childComposition.MelodicLines[i].IsModifiable)
                    for (int j = 0; j < childComposition.Length; j++)
                    {
                        int randComposition = RandomSingleton.Next(0, 2);
                        if (randComposition == 1)
                            childComposition.MelodicLines[i].SetPitch(i, composition2.MelodicLines[i].GetPitch(j).Copy());
                    }

            return childComposition;
        }

        public static void CompositionSelection(List<Composition> population, Func<Composition, int> goalFunction)
        {
            throw new NotImplementedException();
        }
    }
}
