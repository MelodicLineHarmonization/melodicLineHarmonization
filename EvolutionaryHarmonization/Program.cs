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
        private static readonly int iterationCount = 1000;


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

            EvolutionSimulation evolutionSimulation = new(random);
            evolutionSimulation.CreateStartPopulation(baseComposition, populationCount);

            Console.WriteLine("=============================");
            Console.WriteLine("Start population statistics: ");
            Console.WriteLine("Max value: " + evolutionSimulation.SimulationStatistics[^1].MaxValue);
            Console.WriteLine("Standard deviation: " + evolutionSimulation.SimulationStatistics[^1].StandardDeviation);
            Console.WriteLine("Is best correct: " + evolutionSimulation.SimulationStatistics[^1].IsMaxCorrect);

            for (int i = 0; i < iterationCount; i++)
            {
                evolutionSimulation.CreateNextGeneration();
                Console.WriteLine("=============================");
                Console.WriteLine($"Population {i + 1} statistics: ");
                Console.WriteLine("Max value: " + evolutionSimulation.SimulationStatistics[^1].MaxValue);
                Console.WriteLine("Standard deviation: " + evolutionSimulation.SimulationStatistics[^1].StandardDeviation);
                Console.WriteLine("Is best correct: " + evolutionSimulation.SimulationStatistics[^1].IsMaxCorrect);
            }

            evolutionSimulation.SimulationStatistics[^1].BestComposition.SaveToFile("BestComposition.json");
            string statisticsJson = JsonConvert.SerializeObject(evolutionSimulation.SimulationStatistics);
            File.WriteAllText("WholeStatistics.json", statisticsJson);
        }
    }
}
