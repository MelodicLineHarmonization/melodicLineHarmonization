using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Helpers
{
    public static class SimulationStatisticsExtension
    {
        public static readonly string csvStatisticsHeader = "Seed; PopulationSize; CrossoverProbability; MutationFractionProbability; BasicWorstTournamentParticipantProbability;" +
            "IterationNr; AbosluteMaxValue; IsBestCorrect; AbsoluteMean; AbsoluteStandardDeviation; CorrectPercentage\n";
        public static string CreateCsvString(this List<PopulationStatistics> statistics, int seed, int populationSize,
            double crossoverProbability, double mutationFractionProbability, double basicWorstTournamentParticipantProbability)
        {
            string csvString = "";
            string basicCsvString = $"{seed}; {populationSize}; {crossoverProbability}; {mutationFractionProbability}; {basicWorstTournamentParticipantProbability}; ";
            foreach (PopulationStatistics statistic in statistics)
                csvString += basicCsvString + $"{statistic.IterationNumber}; {statistic.AbsoluteMaxValue}; {statistic.IsMaxCorrect}; {statistic.AbsoluteMean}; {statistic.AbsoluteStandardDeviation}; {statistic.CorrectUnitsPrecentage}\n";

            return csvString;
        }

        public static string CreatePopulationScoresCsv(this List<PopulationStatistics> statistics)
        {
            string csvString = "";
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < statistics[i].PopulationAbsoluteScores.Count; j++)
                    csvString += $"{statistics[i].PopulationAbsoluteScores[j]};{statistics[i].PopulationCorrectness[j]};";

                csvString += '\n';
                Console.WriteLine($"{i}");
            }

            return csvString;
        }
    }
}
