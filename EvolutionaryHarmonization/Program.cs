using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EvolutionaryHarmonization
{
    class Program
    {
        private static readonly int populationCount = 1000;
        private static readonly SimpleRandom random = new(new Random());
        private static readonly int iterationCount = 2000;


        static void Main(string[] args)
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5 }, new HarmonicFunction { Function = Degree.I}),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6 }, new HarmonicFunction { Function = Degree.I}),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6 }, new HarmonicFunction { Function = Degree.IV}),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6 }, new HarmonicFunction { Function = Degree.IV}),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5 }, new HarmonicFunction { Function = Degree.I}),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5 }, new HarmonicFunction { Function = Degree.V}),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5 }, new HarmonicFunction { Function = Degree.V}),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5 }, new HarmonicFunction { Function = Degree.I}),
            };
            BaseComposition baseComposition = new BaseComposition { Key = Keys.G, PitchesAndFunctions = pitchesAndFunctions };
            baseComposition.SaveToFile("BaseExample.json");
            List<PopulationStatistics> statisticsList = new();

            (List<CompositionUnit> population, PopulationStatistics statistics) = EvolutionaryFunctions.CreateStartPopulation(baseComposition, populationCount, random);
            statisticsList.Add(statistics);
            Console.WriteLine("=============================");
            Console.WriteLine("Start population statistics: ");
            Console.WriteLine("Max value: " + statistics.MaxValue);
            Console.WriteLine("Standard deviation: " + statistics.StandardDeviation);
            Console.WriteLine("Is best correct: " + statistics.IsMaxCorrect);

            for (int i = 0; i < iterationCount; i++)
            {
                (population, statistics) = EvolutionaryFunctions.CreateNextGeneration(population, random);
                statisticsList.Add(statistics);
                Console.WriteLine("=============================");
                Console.WriteLine($"Population {i + 1} statistics: ");
                Console.WriteLine("Max value: " + statistics.MaxValue);
                Console.WriteLine("Standard deviation: " + statistics.StandardDeviation);
                Console.WriteLine("Is best correct: " + statistics.IsMaxCorrect);
            }

            statistics.BestComposition.SaveToFile("BestComposition.json");
            string statisticsJson = JsonConvert.SerializeObject(statisticsList);
            File.WriteAllText("WholeStatistics.json", statisticsJson);
        }
    }
}
