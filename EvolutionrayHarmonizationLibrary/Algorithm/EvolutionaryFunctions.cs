﻿using EvolutionrayHarmonizationLibrary.Enums;
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
        private static readonly int compositionMelodicLineCount = 4;
        private static readonly int eliteSize = 3;
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
            if (compositionUnit1.PopulationNumber != compositionUnit2.PopulationNumber)
                throw new ArgumentException("Cannot crossover compositions from different populations.");

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

            return new CompositionUnit(childComposition, compositionUnit1.PopulationNumber + 1);
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

        public static List<CompositionUnit> CreateStartPopulation(BaseComposition baseComposition, int populationCount)
        {
            List<CompositionUnit> population = new List<CompositionUnit>();
            for (int i = 0; i < populationCount; i++)
            {
                Composition composition = new Composition(baseComposition);
                while (composition.MelodicLines.Count < compositionMelodicLineCount)
                {
                    int melodicLineIndex = composition.MelodicLines.Count;
                    List<Pitch> newMelodicLinePitches = new List<Pitch>();
                    for (int j = 0; j < composition.Length; j++)
                        newMelodicLinePitches.Add(GetRandomPitchFromFunctionForVoice(composition.Functions[j], composition.Key, melodicLineIndex));

                    composition.MelodicLines.Add(new MelodicLine(newMelodicLinePitches, true));
                }
                population.Add(new CompositionUnit(composition, 0));
            }

            return population;
        }

        public static List<CompositionUnit> CreateNextGeneration(List<CompositionUnit> population)
        {
            List<CompositionUnit> newPopulation = new List<CompositionUnit>();
            for (int i = 0; i < population.Count - eliteSize; i++)
                newPopulation.Add(CreateNextUnit(population));

            population.Sort((e1, e2) => e1.Score.CompareTo(e2.Score));

            for (int i = 1; i <= eliteSize; i++)
                newPopulation.Add(new CompositionUnit(population[^i].Composition, population[^i].PopulationNumber + 1));

            return newPopulation;
        }

        //TODO Spytać się, czy dwie takie same to problem!
        private static CompositionUnit CreateNextUnit(List<CompositionUnit> population)
        {
            CompositionUnit unit1 = CompositionSelection(population);
            CompositionUnit unit2 = CompositionSelection(population);
            CompositionUnit childUnit = CrossoverCompositions(unit1, unit2);
            MutateComposition(childUnit);

            return childUnit;
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
