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
        private static readonly int tournamentSize = 4;

        /// <summary>
        /// Mutacja klasyczna - szansa na mutację każdego akordu wynosi 1/(długość kompozycji).
        /// Mutacja akordu - jeden dźwięk zmieniany na inny, całkowicie losowy.
        /// </summary>
        /// <param name="composition"></param>
        public static void MutateComposition(CompositionUnit compositionUnit)
        {
            Composition composition = compositionUnit.Composition;
            double mutationProbability = 1.0 / composition.Length;
            List<int> possibleModifiyIndices = new List<int>();
            
            for (int i = 0; i < composition.MelodicLines.Count; i++)
                if (composition.MelodicLines[i].IsModifiable)
                    possibleModifiyIndices.Add(i);


            for (int i = 0; i < composition.Length; i++)
                if (RandomSingleton.NextDouble() <= mutationProbability)
                {
                    int index = RandomSingleton.Next(0, possibleModifiyIndices.Count);
                    int melodicLineIndex = possibleModifiyIndices[index];
                    Pitch newPitch = GetRandomPitchFromFunctionForVoice(composition.Functions[i], composition.Key, melodicLineIndex);
                    composition.MelodicLines[melodicLineIndex].SetPitch(i, newPitch);
                }
        }

        /// <summary>
        /// Krzyżowanie klasyczne - krzyżowanie następuje dźwiękami (pojedynczy dźwięk może zostać podmieniony)
        /// </summary>
        /// <param name="composition1"></param>
        /// <param name="composition2"></param>
        public static CompositionUnit CrossoverCompositions(CompositionUnit compositionUnit1, CompositionUnit compositionUnit2)
        {
            Composition composition1 = compositionUnit1.Composition;
            Composition composition2 = compositionUnit2.Composition;
            Composition childComposition = composition1.Copy();

            for (int i = 0; i < childComposition.MelodicLines.Count; i++)
                if (childComposition.MelodicLines[i].IsModifiable)
                    for (int j = 0; j < childComposition.Length; j++)
                    {
                        int randComposition = RandomSingleton.Next(0, 2);
                        if (randComposition == 1)
                            childComposition.MelodicLines[i].SetPitch(i, composition2.MelodicLines[i].GetPitch(j).Copy());
                    }

            return new CompositionUnit(childComposition);
        }

        public static CompositionUnit CompositionSelection(List<CompositionUnit> population)
        {
            int[] indices = new int[tournamentSize];
            for (int i = 0; i < tournamentSize; i++)
            {
                int index = RandomSingleton.Next(0, population.Count);
                while (indices.Contains(index))
                    index = (index + 1) % population.Count;

                indices[i] = index;
            }

            int maxScoreIndex = 0;
            for (int i = 1; i < indices.Length; i++)
                if (population[indices[maxScoreIndex]].Score < population[indices[i]].Score)
                    maxScoreIndex = i;

            return population[indices[maxScoreIndex]];
        }

        private static Pitch GetRandomPitchFromFunctionForVoice(HarmonicFunction harmonicFunction, Keys key, int voiceIndex)
        {
            List<PitchInChord> possiblePitches = harmonicFunction.GetPitchesInFunction(key);
            int pitchIndex = RandomSingleton.Next(0, possiblePitches.Count);
            Pitch selectedPitch = possiblePitches[pitchIndex].Pitch.Copy();
            (Pitch minPitch, Pitch maxPitch) = MelodicLine.VoicesRange[voiceIndex];
            
            selectedPitch.Octave = minPitch.Octave;
            int minOctave = selectedPitch >= minPitch ? minPitch.Octave : minPitch.Octave + 1;
            
            selectedPitch.Octave = maxPitch.Octave;
            int maxOctave = selectedPitch <= maxPitch ? maxPitch.Octave : maxPitch.Octave - 1;

            int octaveOffset = RandomSingleton.Next(0, maxOctave - minOctave + 1);
            selectedPitch.Octave = minOctave + octaveOffset;

            return selectedPitch;
        }
    }
}
