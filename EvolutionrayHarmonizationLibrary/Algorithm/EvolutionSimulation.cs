using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Helpers.Interfaces;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm
{
    public class EvolutionSimulation
    {
        private static readonly int compositionMelodicLineCount = 4;
        private static readonly int eliteSize = 3;
        private static readonly int tournamentSize = 4;
        private static readonly double crossoverProbability = 0.8;
        
        private readonly IRandom random;
        public List<CompositionUnit> Population { get; private set; }
        public List<PopulationStatistics> SimulationStatistics { get; private set; }


        public EvolutionSimulation(IRandom random = null)
        {
            if (random == null)
                this.random = new SimpleRandom(new Random());
            else
                this.random = random;

            SimulationStatistics = new();
        }



        /// <summary>
        /// Mutacja klasyczna - szansa na mutację każdego akordu wynosi 1/(długość kompozycji).
        /// Mutacja akordu - jeden dźwięk zmieniany na inny, całkowicie losowy.
        /// </summary>
        /// <param name="composition"></param>
        private void MutateComposition(CompositionUnit compositionUnit)
        {
            Composition composition = compositionUnit.Composition;
            double mutationProbability = 1.0 / composition.Length;
            List<int> possibleModifiyIndices = new();
            
            for (int i = 0; i < composition.MelodicLines.Count; i++)
                if (composition.MelodicLines[i].IsModifiable)
                    possibleModifiyIndices.Add(i);


            for (int i = 0; i < composition.Length; i++)
                if (random.NextDouble() <= mutationProbability)
                {
                    int index = random.Next(0, possibleModifiyIndices.Count);
                    int melodicLineIndex = possibleModifiyIndices[index];
                    Pitch newPitch = GetRandomPitchFromFunctionForVoice(composition.Functions[i], composition.Key, melodicLineIndex);
                    composition.MelodicLines[melodicLineIndex].SetPitch(i, newPitch);
                }

            compositionUnit.RecalculateScore();
        }

        /// <summary>
        /// Krzyżowanie klasyczne - krzyżowanie następuje dźwiękami (pojedynczy dźwięk może zostać podmieniony)
        /// </summary>
        /// <param name="composition1"></param>
        /// <param name="composition2"></param>
        private CompositionUnit CrossoverCompositions(CompositionUnit compositionUnit1, CompositionUnit compositionUnit2)
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
                        int randComposition = random.Next(0, 2);
                        if (randComposition == 1)
                            childComposition.MelodicLines[i].SetPitch(i, composition2.MelodicLines[i].GetPitch(j).Copy());
                    }

            return new CompositionUnit(childComposition, compositionUnit1.PopulationNumber + 1);
        }

        private CompositionUnit CompositionSelection()
        {
            int[] indices = new int[tournamentSize];
            for (int i = 0; i < tournamentSize; i++)
            {
                int index = random.Next(0, Population.Count);
                while (indices.Contains(index))
                    index = (index + 1) % Population.Count;

                indices[i] = index;
            }

            int maxScoreIndex = 0;
            for (int i = 1; i < indices.Length; i++)
                if (Population[indices[maxScoreIndex]].Score < Population[indices[i]].Score)
                    maxScoreIndex = i;

            return Population[indices[maxScoreIndex]];
        }

        public void CreateStartPopulation(BaseComposition baseComposition, int populationCount)
        {
            List<CompositionUnit> population = new();
            for (int i = 0; i < populationCount; i++)
            {
                Composition composition = new(baseComposition);
                while (composition.MelodicLines.Count < compositionMelodicLineCount)
                {
                    int melodicLineIndex = composition.MelodicLines.Count;
                    List<Pitch> newMelodicLinePitches = new();
                    for (int j = 0; j < composition.Length; j++)
                        newMelodicLinePitches.Add(GetRandomPitchFromFunctionForVoice(composition.Functions[j], composition.Key, melodicLineIndex));

                    composition.MelodicLines.Add(new MelodicLine(newMelodicLinePitches, true));
                }
                population.Add(new CompositionUnit(composition, 0));
            }

            Population = population;
            SimulationStatistics.Add(CalculatePopulationStatistics());
        }

        public void CreateNextGeneration()
        {
            List<CompositionUnit> newPopulation = new();
            for (int i = 0; i < Population.Count - eliteSize; i++)
                newPopulation.Add(CreateNextUnit());

            Population.Sort((e1, e2) => e1.Score.CompareTo(e2.Score));

            for (int i = 1; i <= eliteSize; i++)
                newPopulation.Add(new CompositionUnit(Population[^i].Composition, Population[^i].PopulationNumber + 1));

            Population = newPopulation;
            SimulationStatistics.Add(CalculatePopulationStatistics());
        }

        private CompositionUnit CreateNextUnit()
        {
            CompositionUnit unit1 = CompositionSelection();
            CompositionUnit childUnit;
            if (random.NextDouble() <= crossoverProbability)
            {
                CompositionUnit unit2 = CompositionSelection();
                childUnit = CrossoverCompositions(unit1, unit2);
            }
            else
                childUnit = new CompositionUnit(unit1.Composition.Copy(), unit1.PopulationNumber + 1);

            MutateComposition(childUnit);
            return childUnit;
        }

        private Pitch GetRandomPitchFromFunctionForVoice(HarmonicFunction harmonicFunction, Keys key, int voiceIndex)
        {
            List<PitchInChord> possiblePitches = harmonicFunction.GetPitchesInFunction(key);
            int pitchIndex = random.Next(0, possiblePitches.Count);
            Pitch selectedPitch = possiblePitches[pitchIndex].Pitch.Copy();
            (Pitch minPitch, Pitch maxPitch) = MelodicLine.VoicesRange[voiceIndex];
            
            selectedPitch.Octave = minPitch.Octave;
            int minOctave = selectedPitch >= minPitch ? minPitch.Octave : minPitch.Octave + 1;
            
            selectedPitch.Octave = maxPitch.Octave;
            int maxOctave = selectedPitch <= maxPitch ? maxPitch.Octave : maxPitch.Octave - 1;

            int octaveOffset = random.Next(0, maxOctave - minOctave + 1);
            selectedPitch.Octave = minOctave + octaveOffset;

            return selectedPitch;
        }

        private PopulationStatistics CalculatePopulationStatistics()
        {
            PopulationStatistics populationStatistics = new();
            populationStatistics.IterationNumber = Population[0].PopulationNumber;
            CompositionUnit bestUnit = Population.Aggregate((e1, e2) => e1.Score > e2.Score ? e1 : e2);
            populationStatistics.MaxValue = bestUnit.Score;
            populationStatistics.AbsoluteMaxValue = bestUnit.AbsoluteScore;
            populationStatistics.IsMaxCorrect = bestUnit.IsCorrect;
            populationStatistics.BestComposition = bestUnit.Composition;

            populationStatistics.Mean = Population.Average(x => x.Score);
            
            double sumOfSquaresOfDifferences = Population.Select(x => (x.Score - populationStatistics.Mean) * (x.Score - populationStatistics.Mean)).Sum();
            populationStatistics.StandardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / Population.Count);

            populationStatistics.AbsoulteMean = Population.Average(x => x.AbsoluteScore);
            sumOfSquaresOfDifferences = Population.Select(x => (x.AbsoluteScore - populationStatistics.AbsoulteMean) * (x.AbsoluteScore - populationStatistics.AbsoulteMean)).Sum();
            populationStatistics.StandardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / Population.Count);

            double correctCount = Population.Count(x => x.IsCorrect);
            populationStatistics.CorrectUnitsPrecentage = correctCount / Population.Count;

            return populationStatistics;
        }
    }
}
