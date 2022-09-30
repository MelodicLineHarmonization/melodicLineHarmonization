using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvolutionaryHarmonization
{
    class Program
    {
        private static readonly int populationCount = 1_000;
        private static readonly int iterationCount = 5_000;
        private static readonly List<int> seeds = new() { 0, 1234, 2345, 3456, 4567 };

        static void Main(string[] args) 
        {
            CreateResultsForExamples(ModalHarmonizationExamples.AllExamplesCreateFunctions);

            //BaseComposition baseComposition = ModalHarmonizationExamples.ModalHarmonizationSanctusXIV();
            //if (baseComposition != null)
            //    RunSimulation(baseComposition);
        }


        private static void RunTests(List<Func<BaseComposition>> compositionsToTest, List<double> mutationProbabilities)
        {
            foreach (Func<BaseComposition> baseCompositionFunc in compositionsToTest)
            {
                BaseComposition composition = baseCompositionFunc();
                foreach (double mutationProbability in mutationProbabilities)
                {
                    foreach (int seed in seeds)
                    {
                        Directory.CreateDirectory($"{composition.Name}/{seed}/mutationProbability");
                        Console.WriteLine("=============================");
                        Console.WriteLine($"Calculating {composition.Name} for mutation probability {mutationProbability} and seed {seed}");
                        EvolutionSimulation evolutionSimulation = new EvolutionSimulation(new SimpleRandom(seed), basicWorstTournamentParticipantProbability: 0.3, mutationFractionProbability: mutationProbability, crossoverProbability: 0.8);
                        evolutionSimulation.CreateStartPopulation(composition, populationCount);
                        for (int i = 0; i < iterationCount; i++)
                        {
                            if (i % 1000 == 0)
                                Console.WriteLine(i);
                            evolutionSimulation.CreateNextGeneration();
                        }

                        var simulationParameters = evolutionSimulation.GetSimulationParameters();
                        string csvString = SimulationStatisticsExtension.csvStatisticsHeader + evolutionSimulation.SimulationStatistics.CreateCsvString(seed, populationCount, 4, 3, simulationParameters.crossoverProbability, simulationParameters.mutationFractionProbability, simulationParameters.basicWorstTournamentParticipantProbability);
                        File.WriteAllText($"{composition.Name}/{seed}/mutationProbability/Probability_{mutationProbability}.csv", csvString);                   
                    }
                }
            }
        }

        private static void CreateResultsForExamples(List<Func<BaseComposition>> compositionExamples)
        {
            Dictionary<string, List<TimeSpan>> times = new();

            foreach (Func<BaseComposition> compositionExample in compositionExamples)
            {
                BaseComposition bc = compositionExample();
                times[bc.Name] = new();
                foreach (int seed in seeds)
                {
                    Stopwatch stopwatch = new();
                    stopwatch.Start();
                    RunSimulation(bc, seed, false);
                    stopwatch.Stop();
                    times[bc.Name].Add(stopwatch.Elapsed);
                    Console.WriteLine($"Calculated in {stopwatch.Elapsed}");
                }
            }

            string timesCsv = JsonConvert.SerializeObject(times, new KeyValuePairConverter());
            File.WriteAllText("times.json", timesCsv);
        }

        private static void RunSimulation(BaseComposition baseComposition, int? seed = null, bool showLogs = true)
        {
            if (!seed.HasValue)
                seed = new Random().Next();
            
            Console.WriteLine($"Calculating example {baseComposition.Name} for seed {seed.Value}");

            EvolutionSimulation evolutionSimulation = new(new SimpleRandom(seed.Value), mutationFractionProbability: 1, basicWorstTournamentParticipantProbability: 0.4,  crossoverProbability: 0.8, useSeptimChordsInModal: false);
            evolutionSimulation.CreateStartPopulation(baseComposition, populationCount);

            if (showLogs)
            {
                Console.WriteLine("=============================");
                Console.WriteLine("Start population statistics: ");
                Console.WriteLine("Max value: " + evolutionSimulation.SimulationStatistics[^1].MaxValue);
                Console.WriteLine("Mean value: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteMean);
                Console.WriteLine("Standard deviation: " + evolutionSimulation.SimulationStatistics[^1].AbsoluteStandardDeviation);
                Console.WriteLine("Is best correct: " + evolutionSimulation.SimulationStatistics[^1].IsMaxCorrect);
                Console.WriteLine("Correct percentage: " + evolutionSimulation.SimulationStatistics[^1].CorrectUnitsPrecentage);
                Console.WriteLine("Count of best: " + evolutionSimulation.SimulationStatistics[^1].CountOfBest);
                Console.WriteLine("Different best: " + evolutionSimulation.SimulationStatistics[^1].BestCompositions.Count);
            }

            for (int i = 0; i < iterationCount; i++)
            {
                evolutionSimulation.CreateNextGeneration();
                if (showLogs && i % 100 == 0)
                {
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
            }

            Directory.CreateDirectory($"{baseComposition.Name}Results/{seed.Value}");
            var simulationParameters = evolutionSimulation.GetSimulationParameters();
            for (int i = 0; i < evolutionSimulation.SimulationStatistics[^1].BestCompositions.Count; i++)
            {
                //evolutionSimulation.SimulationStatistics[^1].BestCompositions[i].SaveToFile($"{baseComposition.Name}Results/{seed.Value}/{baseComposition.Name}{i + 1}.json");
                string csvString = SimulationStatisticsExtension.csvStatisticsHeader + evolutionSimulation.SimulationStatistics.CreateCsvString(seed.Value, populationCount, 4, 3, simulationParameters.crossoverProbability, simulationParameters.mutationFractionProbability, simulationParameters.basicWorstTournamentParticipantProbability);
                File.WriteAllText($"{baseComposition.Name}Results/{seed.Value}/{baseComposition.Name}{i + 1}.csv", csvString);
            }
            //string statisticsJson = JsonConvert.SerializeObject(evolutionSimulation.SimulationStatistics, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
            //File.WriteAllText("WholeStatistics.json", statisticsJson);
        }

        private static string GetFilePath()
        {
            Console.WriteLine("Insert file path:");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("File does not exist, enter file path:");
                path = Console.ReadLine();
            }

            return path;
        }
    }
}
