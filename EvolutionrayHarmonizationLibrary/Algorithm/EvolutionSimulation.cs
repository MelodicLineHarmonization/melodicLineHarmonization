﻿using EvolutionrayHarmonizationLibrary.Enums;
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
        private readonly int eliteSize = 3;
        private readonly int tournamentSize = 4;
        private readonly double septimChordProbability = 0.164;
        private readonly double crossoverProbability = 0.8;
        private readonly double basicWorstTournamentParticipantProbability = 0.2;
        private readonly double mutationFractionProbability = 1.1;

        private readonly bool useSeptimChordsInModal = false;

        private readonly IRandom random;

        private List<double> tournamentWinningProbabilities;
        private Dictionary<HarmonicFunction, Dictionary<Pitch, List<Pitch[]>>> functionsDict;

        public List<CompositionUnit> Population { get; private set; }
        public List<PopulationStatistics> SimulationStatistics { get; private set; }


        public EvolutionSimulation(IRandom random = null, double crossoverProbability = 0.8, 
            double basicWorstTournamentParticipantProbability = 0.2, double mutationFractionProbability = 1.1, int tournamentSize = 4, int eliteSize = 3, bool useSeptimChordsInModal = false)
        {
            this.eliteSize = eliteSize;
            this.crossoverProbability = crossoverProbability;
            this.basicWorstTournamentParticipantProbability = basicWorstTournamentParticipantProbability;
            this.mutationFractionProbability = mutationFractionProbability;
            this.useSeptimChordsInModal = useSeptimChordsInModal;
            this.tournamentSize = tournamentSize;
            CreateTournamentProbabilites();
            if (random == null)
                this.random = new SimpleRandom(new Random().Next());
            else
                this.random = random;

            SimulationStatistics = new();
        }

        public (int seed, double crossoverProbability, double mutationFractionProbability, double basicWorstTournamentParticipantProbability) GetSimulationParameters()
        {
            return (random.GetSeed(), crossoverProbability, mutationFractionProbability, basicWorstTournamentParticipantProbability);
        }

        /// <summary>
        /// Mutacja klasyczna - szansa na mutację każdego akordu wynosi 1/(długość kompozycji).
        /// Mutacja akordu - zamiana na inny losowy akord (spełniający ograniczenia właściwego podwojenia dźwięku).
        /// </summary>
        /// <param name="composition"></param>
        private void MutateComposition(CompositionUnit compositionUnit)
        {
            Composition composition = compositionUnit.Composition;
            double mutationProbability = mutationFractionProbability / composition.Length;
            int fixedLineIndex = -1;
            for (int lineIndex = 0; lineIndex < composition.MelodicLines.Count; lineIndex++)
                if (!composition.MelodicLines[lineIndex].IsModifiable)
                {
                    fixedLineIndex = lineIndex;
                    break;
                }

            for (int i = 0; i < composition.Length; i++)
                if (random.NextDouble() <= mutationProbability)
                {
                    if (useSeptimChordsInModal && random.NextDouble() <= septimChordProbability && 
                        CheckIfSeptimChordPossible(i, composition.Length, composition.Functions[i], composition.MelodicLines[fixedLineIndex].GetPitch(i), composition.Key))
                        AddRemoveSeptimFromFunction(composition.Functions[i]);

                        Pitch[] chord = GetRandomChordForFunctionAndPitch(composition.Functions[i], composition.MelodicLines[fixedLineIndex].GetPitch(i));
                    for (int lineIndex = 0; lineIndex < composition.MelodicLines.Count; lineIndex++)
                        if (composition.MelodicLines[lineIndex].IsModifiable)
                            composition.MelodicLines[lineIndex].SetPitch(i, chord[lineIndex]);
                }

            compositionUnit.RecalculateScore();
        }

        private bool CheckIfSeptimChordPossible(int index, int compositionLength, HarmonicFunction function, Pitch melodyPitch, Keys key)
        {
            if (index != 0 && index != compositionLength)
            {
                List<PitchInChord> possiblePitches = function.GetPitchesInFunction(key);
                if (possiblePitches.Find(piC => piC.Pitch == melodyPitch) != null)
                    return true;
            }

            return false;
        }


        private CompositionUnit OnePointCrossoverCompositions(CompositionUnit compositionUnit1, CompositionUnit compositionUnit2)
        {
            if (compositionUnit1.PopulationNumber != compositionUnit2.PopulationNumber)
                throw new ArgumentException("Cannot crossover compositions from different populations.");

            Composition composition1 = compositionUnit1.Composition;
            Composition composition2 = compositionUnit2.Composition;
            Composition childComposition = composition1.Copy();

            int crossoverPoint = random.Next(0, childComposition.Length);

            for (int i = crossoverPoint; i < childComposition.Length; i++)
            {
                childComposition.Functions[i] = composition2.Functions[i].Copy();
                for (int lineIndex = 0; lineIndex < childComposition.MelodicLines.Count; lineIndex++)
                    if (childComposition.MelodicLines[lineIndex].IsModifiable)
                        childComposition.MelodicLines[lineIndex].SetPitch(i, composition2.MelodicLines[lineIndex].GetPitch(i).Copy());
            }

            return new CompositionUnit(childComposition, compositionUnit1.PopulationNumber + 1);
        }

        /// <summary>
        /// Krzyżowanie klasyczne - krzyżowanie następuje akordami (akord z jednej kompozycji może być zamieniony na akord z drugiej)
        /// </summary>
        /// <param name="composition1"></param>
        /// <param name="composition2"></param>
        private CompositionUnit ClassicCrossoverCompositions(CompositionUnit compositionUnit1, CompositionUnit compositionUnit2)
        {
            if (compositionUnit1.PopulationNumber != compositionUnit2.PopulationNumber)
                throw new ArgumentException("Cannot crossover compositions from different populations.");

            Composition composition1 = compositionUnit1.Composition;
            Composition composition2 = compositionUnit2.Composition;
            Composition childComposition = composition1.Copy();

            for (int i = 0; i < childComposition.Length; i++)
            {
                int randComposition = random.Next(0, 2);
                if (randComposition == 1)
                {
                    childComposition.Functions[i] = composition2.Functions[i].Copy();
                    for (int lineIndex = 0; lineIndex < childComposition.MelodicLines.Count; lineIndex++)
                        if (childComposition.MelodicLines[lineIndex].IsModifiable)
                            childComposition.MelodicLines[lineIndex].SetPitch(i, composition2.MelodicLines[lineIndex].GetPitch(i).Copy());
                }
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

            Array.Sort(indices, (i1, i2) => Population[i1].Score.CompareTo(Population[i2].Score));
            double winner = random.NextDouble();
            int winnerIndex = 0;
            while (winner < tournamentWinningProbabilities[winnerIndex])
                winnerIndex++;


            return Population[indices[^(winnerIndex + 1)]];
        }

        public void CreateStartPopulation(BaseComposition baseComposition, int populationCount)
        {
            int fixedMelodicLineIndex = baseComposition.VoiceIndex;
            CreateFunctionDictionary(baseComposition.GetFunctions(), baseComposition.Key, fixedMelodicLineIndex);

            List<CompositionUnit> population = new();
            for (int i = 0; i < populationCount; i++)
            {
                Composition composition = new(baseComposition);
                for (int melodicLineIndex = 0; melodicLineIndex < composition.MelodicLines.Count; melodicLineIndex++)
                    if (melodicLineIndex != fixedMelodicLineIndex)
                        composition.MelodicLines[melodicLineIndex] = new MelodicLine(Enumerable.Repeat<Pitch>(null, composition.Length).ToList(), true);

                for (int index = 0; index < composition.Length; index++)
                {
                    if (useSeptimChordsInModal && random.NextDouble() <= septimChordProbability &&
                        CheckIfSeptimChordPossible(i, composition.Length, composition.Functions[index], composition.MelodicLines[fixedMelodicLineIndex].GetPitch(index), composition.Key))
                        AddRemoveSeptimFromFunction(composition.Functions[index]);

                    Pitch[] chord = GetRandomChordForFunctionAndPitch(composition.Functions[index], composition.MelodicLines[fixedMelodicLineIndex].GetPitch(index));
                    for (int melodicLineIndex = 0; melodicLineIndex < composition.MelodicLines.Count; melodicLineIndex++)
                        if (melodicLineIndex != fixedMelodicLineIndex)
                            composition.MelodicLines[melodicLineIndex].SetPitch(index, chord[melodicLineIndex]);
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
                childUnit = OnePointCrossoverCompositions(unit1, unit2);
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
            
            populationStatistics.CountOfBest = Population.Count(x => x.Score == populationStatistics.MaxValue);
            populationStatistics.PopulationAbsoluteScores = Population.Select(cu => cu.AbsoluteScore).ToList();
            populationStatistics.PopulationCorrectness = Population.Select(cu => Convert.ToInt32(cu.IsCorrect)).ToList();
            List<Composition> differentCompositions = new();
            for (int i = 0; i < Population.Count; i++)
                if (Population[i].Score == populationStatistics.MaxValue)
                {
                    bool isNew = true;
                    foreach (Composition composition in differentCompositions)
                        if (Population[i].Composition.IsSame(composition))
                        {
                            isNew = false;
                            break;
                        }

                    if (isNew)
                        differentCompositions.Add(Population[i].Composition);
                }
            populationStatistics.BestCompositions = differentCompositions;


            populationStatistics.Mean = Population.Average(x => x.Score);
            
            double sumOfSquaresOfDifferences = Population.Select(x => (x.Score - populationStatistics.Mean) * (x.Score - populationStatistics.Mean)).Sum();
            populationStatistics.StandardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / Population.Count);

            populationStatistics.AbsoluteMean = Population.Average(x => x.AbsoluteScore);
            sumOfSquaresOfDifferences = Population.Select(x => (x.AbsoluteScore - populationStatistics.AbsoluteMean) * (x.AbsoluteScore - populationStatistics.AbsoluteMean)).Sum();
            populationStatistics.AbsoluteStandardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / Population.Count);

            double correctCount = Population.Count(x => x.IsCorrect);
            populationStatistics.CorrectUnitsPrecentage = correctCount / Population.Count;

            return populationStatistics;
        }

        private void CreateFunctionDictionary(List<HarmonicFunction> functions, Keys compositionKey, int fixedVoiceIndex)
        {
            functionsDict = new();
            foreach (HarmonicFunction function in functions)
                if (!functionsDict.ContainsKey(function))
                {
                    AddFunctionToDict(function, compositionKey, fixedVoiceIndex);

                    if (useSeptimChordsInModal)
                    {
                        HarmonicFunction functionWithSeptim = function.Copy();
                        functionWithSeptim.AddedDegree = Degree.VII;
                        AddFunctionToDict(functionWithSeptim, compositionKey, fixedVoiceIndex);
                    }
                }
        }

        private Pitch[] GetRandomChordForFunctionAndPitch(HarmonicFunction function, Pitch fixedPitch)
        {
            if (!functionsDict.ContainsKey(function))
                throw new ArgumentException("Function not presented in dictionary!");

            List<Pitch[]> possibleInversions;

            if (!functionsDict[function].ContainsKey(fixedPitch))
                possibleInversions = functionsDict[function].Values.ToList().SelectMany(x => x).Where(x => 
                {
                    return x[1].PitchValue != x[2].PitchValue && x[2].PitchValue != x[3].PitchValue && x[3].PitchValue != x[1].PitchValue;
                }).ToList();
            else
                possibleInversions = functionsDict[function][fixedPitch];

            int chordsCount = possibleInversions.Count;
            int randomIndex = random.Next(0, chordsCount);
            Pitch[] chord = possibleInversions[randomIndex];
            
            for (int i = 1; i < chord.Length; i++)
            {
                chord[i] = chord[i].Copy();
                chord[i].Length = fixedPitch.Length;
            }
            chord[0] = fixedPitch.Copy();

            return chord;
        }

        private void CreateTournamentProbabilites()
        {
            tournamentWinningProbabilities = new();
            double participantProbability = basicWorstTournamentParticipantProbability;
            for (int i = 0; i < tournamentSize - 1; i++)
            {
                tournamentWinningProbabilities.Add(participantProbability);
                participantProbability *= basicWorstTournamentParticipantProbability;
            }

            tournamentWinningProbabilities.Add(0);
        }

        private void AddRemoveSeptimFromFunction(HarmonicFunction function) 
        {
            if (function.AddedDegree == null)
                function.AddedDegree = Degree.VII;
            else
                function.AddedDegree = null;
        }

        private void AddFunctionToDict(HarmonicFunction function, Keys compositionKey, int fixedVoiceIndex)
        {
            List<Pitch[]> inversions = function.GetAllCorrectInversions(compositionKey);
            Dictionary<Pitch, List<Pitch[]>> inversionsDict = new();

            foreach (Pitch[] inversion in inversions)
                if (inversionsDict.ContainsKey(inversion[fixedVoiceIndex]))
                    inversionsDict[inversion[fixedVoiceIndex]].Add(inversion);
                else
                    inversionsDict.Add(inversion[fixedVoiceIndex].Copy(), new List<Pitch[]> { inversion });

            functionsDict.Add(function, inversionsDict);
        }

    }
}
