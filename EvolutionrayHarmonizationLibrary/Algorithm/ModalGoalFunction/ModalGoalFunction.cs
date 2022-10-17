using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm.ModalGoalFunction
{
    public static class ModalGoalFunction
    {
        //weak
        private static readonly int primeInBassFirstChordMultiplier = 200;
        private static readonly int antiParallelOctavesInMelodyAndBassMultiplier = 50;
        private static readonly int quintInBassNotDoubledQuintMultiplier = 20;
        private static readonly int biggerThenQuintMoveMultiplier = 10;
        private static readonly int altTenorWiderThanSixthSpreadMultiplier = 20;
        private static readonly int chordIsNotMoveChord = 150;
        private static readonly int chordIsInInversionAfterMainIctusChord = 150;
        private static readonly int moveOnHiddenQuintsAndOctavesMultiplier = 15;
        
        private static readonly int septimChordOnQuintMultiplier = 50;


        //strong
        private static readonly int parallelQuintsOctavesMultiplier = 100;
        private static readonly int voicesCrossoverMultiplier = 100;
        private static readonly int incorrectDoubledThird = 80;
        private static readonly int augmentedIntervalMoveCountMultiplier = 100;
        private static readonly int doubleQuartQuintMoveCountMultiplier = 50;
        private static readonly int thirdQuintIncorrectMoveInBass = 50;
        
        private static readonly int augumentedQuintInSeptimChordMultiplier = 200;
        private static readonly int incorrectNoteResolutionMultiplier = 150;
        private static readonly int septimNotInAltOrTenorMultiplier = 100;
        private static readonly int septimNotPreparedMultipler = 100;


        //quality
        private static readonly int chordConnectionMultiplier = 20;
        private static readonly int correctMoveThirdInBass = 20;
        private static readonly int isSeptimChordMultiplier = 100;


        private static readonly double C = 0.5;
        private static readonly double alfa = 1;
        private static readonly double beta = 1;

        public static (double, double, bool) CalculateCompositionScore(Composition composition, int populationNumber)
        {
            (double qualitySum, double constraintsWeakSum, double constraintsStrongSum) = CalculateCompostitionScoreForChord(composition);
            (double qualitySumMelodicLines, double constraintsWeakSumMelodicLines, double constraintsStrongSumMelodicLines) = CalculateCompostitionScoreForMelodicLines(composition);

            qualitySum += qualitySumMelodicLines;
            constraintsWeakSum += constraintsWeakSumMelodicLines;
            constraintsStrongSum += constraintsStrongSumMelodicLines;

            return (qualitySum - constraintsWeakSum - Math.Pow((C * populationNumber), alfa) * constraintsStrongSum, qualitySum - constraintsWeakSum - constraintsStrongSum, constraintsStrongSum == 0);
        }

        private static (double qualitySumMelodicLines, double constraintsWeakSumMelodicLines, double constraintsStrongSumMelodicLines) CalculateCompostitionScoreForMelodicLines(Composition composition)
        {
            double qualitySum = 0;
            double constraintsWeakSum = 0;
            double constraintsStrongSum = 0;
            List<List<PitchInChord>> possiblePitchesInFunctions = composition.Functions.ConvertAll((HarmonicFunction f) => f.GetPitchesInFunction(composition.Key));


            for (int i = 1; i < composition.MelodicLines.Count - 1; i++)
            {
                constraintsStrongSum += CalculateStrongConstraintsForAltAndTenor(composition.MelodicLines[i]);
                constraintsWeakSum += CalculateWeakConstraintsForAltAndTenor(composition.MelodicLines[i]);
            }


            qualitySum += CalculateQualityForBass(composition.MelodicLines[^1], possiblePitchesInFunctions);
            constraintsStrongSum += CalculateStrongConstraintsForBass(composition.MelodicLines[^1], possiblePitchesInFunctions);

            return (qualitySum, constraintsWeakSum, constraintsStrongSum);
        }

        private static double CalculateQualityForBass(MelodicLine melodicLine, List<List<PitchInChord>> possiblePitchesInFunctions)
        {
            return ModalQualityFunctions.BassCorrectMovesOnAndOffThrid(melodicLine, possiblePitchesInFunctions) * Math.Pow(correctMoveThirdInBass, beta);
        }

        private static double CalculateStrongConstraintsForBass(MelodicLine melodicLine, List<List<PitchInChord>> possiblePitchesInFunctions)
        {
            double violatedConstraintsSum = 0;
            violatedConstraintsSum += ModalConstraintsFunctions.AugumentedIntervalMoveCount(melodicLine) * Math.Pow(augmentedIntervalMoveCountMultiplier, beta);
            violatedConstraintsSum += ModalConstraintsFunctions.QuartQuintMoveInOneDirection(melodicLine) * Math.Pow(doubleQuartQuintMoveCountMultiplier, beta);
            violatedConstraintsSum += ModalConstraintsFunctions.BassCorrectMovesThirds(melodicLine, possiblePitchesInFunctions) * Math.Pow(thirdQuintIncorrectMoveInBass, beta);
            violatedConstraintsSum += ModalConstraintsFunctions.BassCorrectMovesQuints(melodicLine, possiblePitchesInFunctions) * Math.Pow(thirdQuintIncorrectMoveInBass, beta);


            return violatedConstraintsSum;
        }

        private static double CalculateWeakConstraintsForAltAndTenor(MelodicLine melodicLine)
        {
            return ModalConstraintsFunctions.MelodicLineMaxMove(melodicLine, Interval.quintSemitones.First()) * Math.Pow(biggerThenQuintMoveMultiplier, beta);
        }

        private static double CalculateStrongConstraintsForAltAndTenor(MelodicLine melodicLine)
        {
            return ModalConstraintsFunctions.AugumentedIntervalMoveCount(melodicLine) * Math.Pow(augmentedIntervalMoveCountMultiplier, beta);
        }

        private static (double, double, double) CalculateCompostitionScoreForChord(Composition composition)
        {
            double qualitySum = 0;
            double constraintsWeakSum = 0;
            double constraintsStrongSum = 0;
            Pitch[] chord = composition.GetChordAtPosition(0);
            List<List<PitchInChord>> possiblePitchesInFunctions = composition.Functions.ConvertAll((HarmonicFunction f) => f.GetPitchesInFunction(composition.Key));
            List<PitchInChord> possiblePitches = possiblePitchesInFunctions[0];
            //Sprawdzenie, czy pierwszy akord na prymie
            constraintsWeakSum += IsChordOnPrime(chord, possiblePitches);

            for (int i = 1; i < composition.Length; i++)
            {
                Pitch[] nextChord = composition.GetChordAtPosition(i);
                List<PitchInChord> nextPossiblePitches = possiblePitchesInFunctions[i];
                qualitySum += CalculateQuality(chord, possiblePitches, nextChord, nextPossiblePitches);
                constraintsWeakSum += CalculateWeakConstraintsForChords(chord, possiblePitches, nextChord, nextPossiblePitches, (int)composition.Downbeats.First(), i - 1);
                constraintsStrongSum += CalculateStrongConstraintsForChords(chord, possiblePitches, nextChord, nextPossiblePitches);

                chord = nextChord;
                possiblePitches = nextPossiblePitches;
            }
            //Sprawdzenie, czy pierwszy ostatni akord na prymie
            constraintsWeakSum += IsChordOnPrime(chord, possiblePitchesInFunctions[^1]);


            return (qualitySum, constraintsWeakSum, constraintsStrongSum);  
        }

        private static double CalculateQuality(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord, List<PitchInChord> nextPossiblePitches)
        {
            double quality = 0;
            if (ModalQualityFunctions.ChordMelodicHarmonicConnections(chord, possiblePitches, nextChord, nextPossiblePitches))
                quality += Math.Pow(chordConnectionMultiplier, beta);

            if (possiblePitches.Count == 4) //akord septymowy
                quality += Math.Pow(isSeptimChordMultiplier, beta);

            return quality;
        }

        private static double CalculateStrongConstraintsForChords(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord, List<PitchInChord> nextPossiblePitches)
        {
            double violatedConstraintsScore = 0;
            violatedConstraintsScore += ModalConstraintsFunctions.ParallelQuintsAndOctaves(chord, nextChord) * Math.Pow(parallelQuintsOctavesMultiplier, beta);
            violatedConstraintsScore += ModalConstraintsFunctions.VoicesCrossover(chord) * Math.Pow(voicesCrossoverMultiplier, beta);
            violatedConstraintsScore += ModalConstraintsFunctions.VoicesCrossoverBetweenChords(chord, nextChord) * Math.Pow(voicesCrossoverMultiplier, beta);

            violatedConstraintsScore += ModalConstraintsFunctions.AntiparallelQuintsAndOctaves(chord[1..], nextChord[1..]) * Math.Pow(parallelQuintsOctavesMultiplier, beta);
            violatedConstraintsScore += ModalConstraintsFunctions.AntiparallelQuintsAndOctaves(new Pitch[] { chord[0].AllPitchesOnIcuts.Last(), chord[1] }, new Pitch[] { nextChord[0].AllPitchesOnIcuts.First(), nextChord[1] }) * Math.Pow(parallelQuintsOctavesMultiplier, beta);
            violatedConstraintsScore += ModalConstraintsFunctions.AntiparallelQuintsAndOctaves(new Pitch[] { chord[0].AllPitchesOnIcuts.Last(), chord[2] }, new Pitch[] { nextChord[0].AllPitchesOnIcuts.First(), nextChord[2] }) * Math.Pow(parallelQuintsOctavesMultiplier, beta);

            if (ModalConstraintsFunctions.DegreeInBass(chord, possiblePitches, Degree.III))
            { 
                bool? corretDoubledThird = ModalConstraintsFunctions.CorrectDoubledThird(chord, possiblePitches);
                if (corretDoubledThird.HasValue && !corretDoubledThird.Value)
                    violatedConstraintsScore += Math.Pow(incorrectDoubledThird, beta);
            }

            if (possiblePitches.Count == 4) // akord septymowy
            {
                violatedConstraintsScore += ModalConstraintsFunctions.AugumentedQuintInChord(possiblePitches) ? augumentedQuintInSeptimChordMultiplier : 0;
                violatedConstraintsScore += ModalConstraintsFunctions.SeptimCorrectResolution(chord, possiblePitches, nextChord) ? 0 : incorrectNoteResolutionMultiplier;
                violatedConstraintsScore += ModalConstraintsFunctions.IsSeptimInAltOrTenor(chord, possiblePitches) ? 0 : septimNotInAltOrTenorMultiplier;
            }

            if (nextPossiblePitches.Count == 4) // następny akord spetymowy
            {
                violatedConstraintsScore += ModalConstraintsFunctions.IsSepitmPrepared(chord, nextChord, nextPossiblePitches) ? 0 : septimNotPreparedMultipler;
            }    

            return violatedConstraintsScore;
        }

        private static double CalculateWeakConstraintsForChords(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord, List<PitchInChord> nextPossiblePitche, int mainIctusIndexs, int chordIndex)
        {
            double violatedConstraintsScore = 0;

            violatedConstraintsScore += ModalConstraintsFunctions.AntiparallelOctaves(new Pitch[] { chord[0].AllPitchesOnIcuts.Last(), chord[^1] }, new Pitch[] { nextChord[0].AllPitchesOnIcuts.First(), nextChord[^1] }) * Math.Pow(antiParallelOctavesInMelodyAndBassMultiplier, beta);

            violatedConstraintsScore += ModalQualityFunctions.MoveOnHiddenQuintsAndOctaves(chord, nextChord) * Math.Pow(moveOnHiddenQuintsAndOctavesMultiplier, beta);


            if (ModalConstraintsFunctions.AltTenorWiderThanOctaveSpread(chord))
                violatedConstraintsScore += Math.Pow(altTenorWiderThanSixthSpreadMultiplier, beta);

            violatedConstraintsScore += ModalConstraintsFunctions.AltSopranoWiderThanOctaveSpread(chord) * Math.Pow(altTenorWiderThanSixthSpreadMultiplier, beta);

            if (ModalConstraintsFunctions.DegreeInBass(chord, possiblePitches, Degree.V) && !ModalConstraintsFunctions.IsQuintCorrectDoubled(chord, possiblePitches))
                violatedConstraintsScore += Math.Pow(quintInBassNotDoubledQuintMultiplier, beta);

            if (chordIndex < mainIctusIndexs)
            {
                if (!ModalConstraintsFunctions.IsMoveChord(chord, possiblePitches))
                    violatedConstraintsScore += Math.Pow(chordIsNotMoveChord, beta);
            }
            else
            {
                if (ModalConstraintsFunctions.IsChordInInversion(chord, possiblePitches))
                    violatedConstraintsScore += Math.Pow(chordIsInInversionAfterMainIctusChord, beta);
            }

            if (possiblePitches.Count == 4 && ModalConstraintsFunctions.DegreeInBass(chord, possiblePitches, Degree.V)) // akord septymowy na kwincie
                violatedConstraintsScore += Math.Pow(septimChordOnQuintMultiplier, beta);

            return violatedConstraintsScore;
        }

        private static double IsChordOnPrime(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            if (ModalConstraintsFunctions.DegreeInBass(chord, possiblePitches, Degree.I))
                return 0;

            return Math.Pow(primeInBassFirstChordMultiplier, beta);
        }
    }
}
