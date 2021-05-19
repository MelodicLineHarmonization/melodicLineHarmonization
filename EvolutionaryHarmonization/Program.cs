using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace EvolutionaryHarmonization
{
    class Program
    {
        private static List<int> populationSizes = new List<int>() { 10, 100, 500, 1000, 1750, 2500, 3500, 5000 };

        private static readonly int populationCount = 1_000;
        private static readonly SimpleRandom random = new(0);
        private static readonly int iterationCount = 5000;


        static void Main(string[] args)
        {
            //DetailedExampleTest();
            List<Func<BaseComposition>> funcs = new() { CreateAllDegreesC_S276 };
            List<int> seeds = new() { 0, 1234, 2345, 3456, 4567 };
            PerformTests(funcs, seeds);
        }

        private static void PerformTests(List<Func<BaseComposition>> compositionFuncs, List<int> seeds)
        {
            foreach (int seed in seeds)
            {
                Console.WriteLine($"Running tests for seed {seed}.");
                Parallel.ForEach(compositionFuncs, func => RunTest(func(), seed));
            }
        }

        private static void RunTest(BaseComposition composition, int seed)
        {
            Directory.CreateDirectory($"{composition.Name}\\Seed_{seed}");
            Console.WriteLine($"Running tests for composition {composition.Name}.");
            List<double> crossoverProb = GenerateSteps(0, 1, 0.1);
            List<double> mutationProb = GenerateSteps(0, composition.Length, 1);
            List<double> worstProb = GenerateSteps(0, 1, 0.1);
            PerformTestsForExample(composition, seed, iterationCount, populationSizes, crossoverProb, mutationProb, worstProb);
        }

        private static List<double> GenerateSteps(double minValue, double maxValue, double step) 
        {
            List<double> steps = new();
            double value = minValue;
            while (value <= maxValue)
            {
                steps.Add(value);
                value += step;
            }
            return steps;
        }

        private static string RunSimulation(BaseComposition composition, EvolutionSimulation simulation, int populationSize, int iterationCount)
        {
            simulation.CreateStartPopulation(composition, populationSize);
            for (int i = 0; i < iterationCount; i++)
                simulation.CreateNextGeneration();

            (int seed, double crossoverProb, double mutationFractionProb, double basicWorstTournamentParticipantProb) = simulation.GetSimulationParameters();
            return simulation.SimulationStatistics.CreateCsvString(seed, populationSize, crossoverProb, mutationFractionProb, basicWorstTournamentParticipantProb);
        }

        private static void PerformTestsForExample(BaseComposition composition, int seed, int iterationsCount, List<int> populationSizes,
            List<double> crossoverProbabilities, List<double> mutationFractionProbabilities, List<double> basicWorstTournamentParticipantProbabilities)
        {
            Console.WriteLine($"{composition.Name}: Running simulations for population sizes:");
            Console.WriteLine("=========================================");
            Directory.CreateDirectory($"{composition.Name}\\Seed_{seed}\\populationSizes");
            Parallel.ForEach(populationSizes, size =>
            {
                Console.WriteLine($"{composition.Name}: Simulation for size {size} started.");
                string csvString = SimulationStatisticsExtension.csvStatisticsHeader;
                EvolutionSimulation evolutionSimulation = new(new SimpleRandom(seed));
                csvString += RunSimulation(composition, evolutionSimulation, size, iterationsCount);
                Console.WriteLine($"{composition.Name}: Simulation for size {size} ended. Best found value is {evolutionSimulation.SimulationStatistics[^1].AbsoluteMaxValue}.");
                File.WriteAllText($"{composition.Name}\\Seed_{seed}\\populationSizes\\Size_{size}.csv", csvString);
            });
                        
            Console.WriteLine($"{composition.Name}: Running simulations for crossover probabilities:");
            Console.WriteLine("=========================================");
            Directory.CreateDirectory($"{composition.Name}\\Seed_{seed}\\crossoverProbabilities");
            Parallel.ForEach(crossoverProbabilities, crossoverProbability =>
            {
                Console.WriteLine($"{composition.Name}: Simulation for probability {crossoverProbability} started.");
                string csvString = SimulationStatisticsExtension.csvStatisticsHeader;
                EvolutionSimulation evolutionSimulation = new(new SimpleRandom(seed), crossoverProbability: crossoverProbability);
                csvString += RunSimulation(composition, evolutionSimulation, populationCount, iterationsCount);
                Console.WriteLine($"{composition.Name}: Simulation for probability {crossoverProbability} ended. Best found value is {evolutionSimulation.SimulationStatistics[^1].AbsoluteMaxValue}.");
                File.WriteAllText($"{composition.Name}\\Seed_{seed}\\crossoverProbabilities\\Probability_{crossoverProbability}.csv", csvString);
            });

            Console.WriteLine($"{composition.Name}: Running simulations for mutation probabilities:");
            Console.WriteLine("=========================================");
            Directory.CreateDirectory($"{composition.Name}\\Seed_{seed}\\mutationProbabilities");
            Parallel.ForEach(mutationFractionProbabilities, mutationFractionProbability =>
            {
                Console.WriteLine($"{composition.Name}: Simulation for probability {mutationFractionProbability} started.");
                string csvString = SimulationStatisticsExtension.csvStatisticsHeader;
                EvolutionSimulation evolutionSimulation = new(new SimpleRandom(seed), mutationFractionProbability: mutationFractionProbability);
                csvString += RunSimulation(composition, evolutionSimulation, populationCount, iterationsCount);
                Console.WriteLine($"{composition.Name}: Simulation for probability {mutationFractionProbability} ended. Best found value is {evolutionSimulation.SimulationStatistics[^1].AbsoluteMaxValue}.");
                File.WriteAllText($"{composition.Name}\\Seed_{seed}\\mutationProbabilities\\Probability_{mutationFractionProbability}.csv", csvString);
            });
            
            Console.WriteLine($"{composition.Name}: Running simulations for worst tournament participant probabilities:");
            Console.WriteLine("=========================================");
            Directory.CreateDirectory($"{composition.Name}\\Seed_{seed}\\worstTournamentParticipantProbabilities");
            Parallel.ForEach(basicWorstTournamentParticipantProbabilities, basicWorstTournamentParticipantProbability =>
            {
                Console.WriteLine($"{composition.Name}: Simulation for probability {basicWorstTournamentParticipantProbability} started.");
                string csvString = SimulationStatisticsExtension.csvStatisticsHeader;
                EvolutionSimulation evolutionSimulation = new(new SimpleRandom(seed), basicWorstTournamentParticipantProbability: basicWorstTournamentParticipantProbability);
                csvString += RunSimulation(composition, evolutionSimulation, populationCount, iterationsCount);
                Console.WriteLine($"{composition.Name}: Simulation for probability {basicWorstTournamentParticipantProbability} ended. Best found value is {evolutionSimulation.SimulationStatistics[^1].AbsoluteMaxValue}.");
                File.WriteAllText($"{composition.Name}\\Seed_{seed}\\worstTournamentParticipantProbabilities\\Probability_{basicWorstTournamentParticipantProbability}.csv", csvString);
            });
        }

        private static BaseComposition CreateBaseExample()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I }),
            };
            BaseComposition baseComposition = new() { Name = "BaseExample", VoiceIndex = 0, Key = Keys.G, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("BaseExample.json");
            return baseComposition;
        }

        private static BaseComposition CreateEasyD_S73Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyD_S73", VoiceIndex = 0, Key = Keys.D, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("EasyD_S73.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasyC_S46Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyC_S46", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };
            baseComposition.SaveToFile("EasyC_S46.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasya_S47Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true} }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easya_S47", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("Easya_S47.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasyC_S49Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyC_S49", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };
            baseComposition.SaveToFile("EasyC_S49.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasya_S51Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),

                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easya_S51", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("Easya_S51.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasyd_S107Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easyd_S107", VoiceIndex = 0, Key = Keys.d, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };
            baseComposition.SaveToFile("Easyd_S107.json");

            return baseComposition;
        }

        private static BaseComposition CreateEasyF_S108Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyF_S108", VoiceIndex = 0, Key = Keys.F, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("EasyF_S108.json");

            return baseComposition;
        }

        private static BaseComposition CreateAllDegreesC_S267()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesC_S267", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("AllDegreesC_S267.json");

            return baseComposition;
        }


        private static BaseComposition CreateAllDegreesc_S267()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.Flat, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.Flat, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesc_S267", VoiceIndex = 0, Key = Keys.c, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("AllDegreesc_S267.json");

            return baseComposition;
        }

        private static BaseComposition CreateAllDegreesC_S276()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesC_S276", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };
            baseComposition.SaveToFile("AllDegreesC_S276.json");

            return baseComposition;
        }

        private static BaseComposition CreateAllDegreesc_S282()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesc_S282", VoiceIndex = 0, Key = Keys.c, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };
            baseComposition.SaveToFile("AllDegreesc_S282.json");

            return baseComposition;
        }


        private static BaseComposition CreateEasyWithAddedC_S46Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedC_S46Example", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };
            baseComposition.SaveToFile("EasyWithAddedC_S46Example.json");

            return baseComposition;
        }


        private static void DetailedExampleTest()
        {
            BaseComposition baseComposition = CreateAllDegreesC_S267();
            EvolutionSimulation evolutionSimulation = new(random, crossoverProbability : 0.8, mutationFractionProbability : 1);
            evolutionSimulation.CreateStartPopulation(baseComposition, populationCount);

            Console.WriteLine("=============================");
            Console.WriteLine("Start population statistics: ");
            Console.WriteLine("Max value: " + evolutionSimulation.SimulationStatistics[^1].MaxValue);
            Console.WriteLine("Mean value: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteMean);
            Console.WriteLine("Standard deviation: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteStandardDeviation);
            Console.WriteLine("Is best correct: " + evolutionSimulation.SimulationStatistics[^1].IsMaxCorrect);
            Console.WriteLine("Correct percentage: " + evolutionSimulation.SimulationStatistics[^1].CorrectUnitsPrecentage);
            Console.WriteLine("Count of best: " + evolutionSimulation.SimulationStatistics[^1].CountOfBest);
            Console.WriteLine("Different best: " + evolutionSimulation.SimulationStatistics[^1].BestCompositions.Count);

            for (int i = 0; i < iterationCount; i++)
            {
                evolutionSimulation.CreateNextGeneration();
                Console.WriteLine("=============================");
                Console.WriteLine($"Population {i + 1} statistics: ");
                Console.WriteLine("Max value: " + evolutionSimulation.SimulationStatistics[^1].MaxValue);
                Console.WriteLine("Mean value: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteMean);
                Console.WriteLine("Standard deviation: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteStandardDeviation);
                Console.WriteLine("Is best correct: " + evolutionSimulation.SimulationStatistics[^1].IsMaxCorrect);
                Console.WriteLine("Correct percentage: " + evolutionSimulation.SimulationStatistics[^1].CorrectUnitsPrecentage);
                Console.WriteLine("Count of best: " + evolutionSimulation.SimulationStatistics[^1].CountOfBest);
                Console.WriteLine("Different best: " + evolutionSimulation.SimulationStatistics[^1].BestCompositions.Count);
            }

            for (int i = 0; i < evolutionSimulation.SimulationStatistics[^1].BestCompositions.Count; i++)
                evolutionSimulation.SimulationStatistics[^1].BestCompositions[i].SaveToFile($"BestComposition{i + 1}.json");
            string statisticsJson = JsonConvert.SerializeObject(evolutionSimulation.SimulationStatistics);
            File.WriteAllText("WholeStatistics.json", statisticsJson);
        }
    }
}
