using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm
{
    public static class GoalFunction
    {
        private static readonly int parallelSixthsMultiplier = 10;
        private static readonly int contraryBassSopranoMoveMultiplier = 10;
        private static readonly int contraryMoveOnPerfectIntervalMultiplier = 10;
        private static readonly int toBigBassMoveMultiplier = 25;
        private static readonly int chordBreadthMultiplier = 5;

        private static readonly int septimMoveMultiplier = 10;
        private static readonly int melodicLineSmoothMultiplier = 10;

        private static readonly int followingOnQuintMultiplier = 20;
        private static readonly int doubleQuintNotInBassMultiplier = 30;
        private static readonly int moreThenTwoVoicesWithoutMoveMultiplier = 40;
        private static readonly int tripledFirstMultiplier = 200;
        private static readonly int voicesNotInAppropriateRangeMultiplier = 5;
        private static readonly int quintInBassOnWeakDownbeatMultiplier = 10;
        private static readonly int withoutBassMoveMultiplier = 10;

        private static readonly int augumentedIntervalMoveCountMultiplier = 100;

        private static readonly int voicesCrossoverMultiplier = 100;
        private static readonly int incorrectPitchesInChordMultiplier = 500;
        private static readonly int widerThanOctaveMultiplier = 50;
        private static readonly int incorrectNoteResolutionMultiplier = 200;
        private static readonly int parallelQuintsMultiplier = 100;
        private static readonly int quintInBassOnStrongDownbeatMultiplier = 100;
        private static readonly int allVoicesOneDirectionMultiplier = 100;

        private static readonly int doubleFirstInBassFirstLastChordMultiplier = 500;

        private static readonly double C = 0.5;
        private static readonly double alfa = 1;
        private static readonly double beta = 1;


        public static (double, double, bool) CalculateCompositionScore(Composition composition, int populationNumber)
        {
            (double qualitySum, double constraintsWeakSum, double constraintsStrongSum) = CalculateCompostitionScoreForChord(composition);
            (double constraintsWeakSumMelodicLines, double constraintsStrongSumMelodicLines) = CalculateCompostitionScoreForMelodicLines(composition);

            constraintsWeakSum += constraintsWeakSumMelodicLines;
            constraintsStrongSum += constraintsStrongSumMelodicLines;

            return (qualitySum - constraintsWeakSum - Math.Pow((C * populationNumber), alfa) * constraintsStrongSum, qualitySum - constraintsWeakSum - constraintsStrongSum, constraintsStrongSum == 0);
        }

        private static (double constraintsWeakSum, double constraintsStrongSum) CalculateCompostitionScoreForMelodicLines(Composition composition)
        {
            List<int> indicesForModifiableMelodicLines = new();
            List<int> indicesForSmoothMove = new();
            for (int i = 0; i < composition.MelodicLines.Count; i++)
                if (composition.MelodicLines[i].IsModifiable)
                {
                    indicesForModifiableMelodicLines.Add(i);
                    if (i < composition.MelodicLines.Count - 1)
                        indicesForSmoothMove.Add(i);
                }

            double constraintsWeakSum = CalculateWeakConstraintsForMelodicLines(composition, indicesForModifiableMelodicLines, indicesForSmoothMove);
            double constraintsStrongSum = CalculateStrongConstraintsForMelodicLines(composition, indicesForModifiableMelodicLines);

            return (constraintsWeakSum, constraintsStrongSum);
        }

        private static (double qualitySum, double constraintsWeakSum, double constraintsStrongSum) CalculateCompostitionScoreForChord(Composition composition)
        {
            double chordBeatNumber = 1;
            double qualitySum = 0;
            double constraintsWeakSum = 0;
            double constraintsStrongSum = 0;
            Pitch[] chord = composition.GetChordAtPosition(0);
            HarmonicFunction function = composition.Functions[0];
            // Zdwojona pryma w pierwszym akordzie (akord na prymie)
            constraintsStrongSum += CalculateDoubledFirst(composition.Key, chord, function);

            for (int i = 1; i < composition.Length; i++)
            {
                Pitch[] nextChord = composition.GetChordAtPosition(i);
                HarmonicFunction nextFunction = composition.Functions[i];
                qualitySum += CalculateQuality(chord, nextChord);
                constraintsWeakSum += CalculateWeakConstraintsForChords(composition.Key, chord, function, chordBeatNumber, composition.Downbeats, nextChord, nextFunction);
                constraintsStrongSum += CalculateStrongConstraintsForChords(composition.Key, chord, function, chordBeatNumber, composition.Downbeats, nextChord, nextFunction);

                chordBeatNumber += chord[^1].Length.GetRelativeDuration(composition.TimeSignature.Denominator);
                if (chordBeatNumber >= (composition.TimeSignature.Numerator + 1))
                    chordBeatNumber %= composition.TimeSignature.Numerator;
                chord = nextChord;
                function = nextFunction;
            }
            qualitySum += CalculateQuality(chord);
            constraintsWeakSum += CalculateWeakConstraintsForChords(composition.Key, chord, function, chordBeatNumber, composition.Downbeats);
            constraintsStrongSum += CalculateStrongConstraintsForChords(composition.Key, chord, function, chordBeatNumber, composition.Downbeats);

            constraintsStrongSum += CalculatePenulitmateChordForCorrectBass(composition);
            // Zdwojona pryma w ostatnim akordzie (akord na prymie)
            constraintsStrongSum += CalculateDoubledFirst(composition.Key, chord, function);

            return (qualitySum, constraintsWeakSum, constraintsStrongSum);
        }

        private static double CalculateDoubledFirst(Keys key, Pitch[] chord, HarmonicFunction function)
        {
            List<PitchInChord> possiblePitches = function.GetPitchesInFunction(key);
            bool firstInBass = ConstraintsFunctions.DegreeInBass(chord, possiblePitches, Degree.I);
            bool? doubled = ConstraintsFunctions.MultipliedDegree(chord, possiblePitches, Degree.I, 2);

            if (!doubled.HasValue)
                if (firstInBass)
                    return 0;
                else
                    return Math.Pow(doubleFirstInBassFirstLastChordMultiplier, beta);


            if (!firstInBass || !doubled.Value)
                return Math.Pow(doubleFirstInBassFirstLastChordMultiplier, beta);

            return 0;
        }

        private static double CalculateQuality(Pitch[] chord, Pitch[] nextChord = null)
        {
            if (nextChord != null)
                return QualityFunctions.ParallelSixths(chord, nextChord) * parallelSixthsMultiplier +
                       QualityFunctions.ContraryMoveOnPerfectInterval(chord, nextChord) * contraryMoveOnPerfectIntervalMultiplier +
                       Convert.ToInt32(QualityFunctions.ContraryBassSopranoMove(chord, nextChord)) * contraryBassSopranoMoveMultiplier +
                       QualityFunctions.ChordBreadth(chord) * chordBreadthMultiplier;

            return QualityFunctions.ChordBreadth(chord) * chordBreadthMultiplier;
        }

        private static double CalculateWeakConstraintsForChords(Keys key, Pitch[] chord, HarmonicFunction function, double chordBeatNumber, List<double> downbeats, Pitch[] nextChord = null, HarmonicFunction nextFunction = null)
        {
            List<PitchInChord> chordPossiblePitches = function.GetPitchesInFunction(key);

            int voicesNotInAppropriateRange = ConstraintsFunctions.VoicesNotInAppropriateRange(chord);
            int doubleQuintsNotInBass = 0;
            bool? doubledQuints = ConstraintsFunctions.MultipliedDegree(chord, chordPossiblePitches, Degree.V, 2);
            if (doubledQuints.HasValue && doubledQuints.Value)
                doubleQuintsNotInBass = Convert.ToInt32(!ConstraintsFunctions.DegreeInBass(chord, chordPossiblePitches, Degree.V));

            int quintInBassOnDownbeat = 0;
            int index = downbeats.FindIndex(db => db == chordBeatNumber);
            bool quintInBass = ConstraintsFunctions.DegreeInBass(chord, chordPossiblePitches, Degree.V);
            if (quintInBass)
                if (index != -1 && index != 0) // index == 0 -> strong constraints
                    quintInBassOnDownbeat = downbeats.Count - index + 1;
                else
                    quintInBassOnDownbeat = 1;

            int tripledFirst = 0;
            if (function.Function == Degree.I)
                tripledFirst = Convert.ToInt32(ConstraintsFunctions.MultipliedDegree(chord, chordPossiblePitches, Degree.I, 3));


            if (nextChord != null)
            {
                List<PitchInChord> nextChordPossiblePitches = nextFunction.GetPitchesInFunction(key);
                int followingOnQuints = Convert.ToInt32(ConstraintsFunctions.FollowingChordsOnQuint(chord, chordPossiblePitches, nextChord, nextChordPossiblePitches));
                int withoutBassMove = Convert.ToInt32(!ConstraintsFunctions.BassMove(chord, nextChord));
                int moreThenTwoVoicesWithoutMove = ConstraintsFunctions.AtLeastTwoVoicesMove(chord, nextChord);

                return (followingOnQuints * followingOnQuintMultiplier) +
                       (quintInBassOnDownbeat * quintInBassOnWeakDownbeatMultiplier) +
                       (doubleQuintsNotInBass * doubleQuintNotInBassMultiplier) +
                       (moreThenTwoVoicesWithoutMove * moreThenTwoVoicesWithoutMoveMultiplier) +
                       (voicesNotInAppropriateRange * voicesNotInAppropriateRangeMultiplier) +
                       (withoutBassMove * withoutBassMoveMultiplier) +
                       (tripledFirst * tripledFirstMultiplier);
            }

            return (doubleQuintsNotInBass * doubleQuintNotInBassMultiplier) +
                   (quintInBassOnDownbeat * quintInBassOnWeakDownbeatMultiplier) +
                   (voicesNotInAppropriateRange * voicesNotInAppropriateRangeMultiplier) +
                   (tripledFirst * tripledFirstMultiplier);
        }

        private static double CalculateWeakConstraintsForMelodicLines(Composition composition, List<int> septimeMoveMelodicLinesIndices, List<int> smoothMelodicLinesIndices)
        {
            int septimeMoveSum = 0;
            int melodicLineSmoothSum = 0;
            

            foreach (int index in septimeMoveMelodicLinesIndices)
                septimeMoveSum += ConstraintsFunctions.SeptimeMove(composition.MelodicLines[index]);

            foreach (int index in smoothMelodicLinesIndices)
                melodicLineSmoothSum += ConstraintsFunctions.GetMelodicLineSmooth(composition.MelodicLines[index]).Item1;

            int bigBassMove = ConstraintsFunctions.MelodicLineMaxMoveInTwo(composition.MelodicLines[^1], 15); // oktawa + tercja mała = 15 półtonów

            return (septimeMoveSum * septimMoveMultiplier) +
                   (melodicLineSmoothSum * melodicLineSmoothMultiplier) + 
                   (bigBassMove * toBigBassMoveMultiplier);
        }

        private static double CalculateStrongConstraintsForChords(Keys key, Pitch[] chord, HarmonicFunction function, double chordBeatNumber, List<double> downbeats, Pitch[] nextChord = null, HarmonicFunction nextFunction = null)
        {
            List<PitchInChord> chordPossiblePitches = function.GetPitchesInFunction(key);
            double voicesCrossoverSum = Math.Pow(ConstraintsFunctions.VoicesCrossover(chord), beta);
            double incorrectPitchesSum = Math.Pow(ConstraintsFunctions.IncorrectPitchesInChord(chord, chordPossiblePitches), beta);
            double widerThanOctaveSum = Math.Pow(ConstraintsFunctions.WiderThanOctaveSpread(chord), beta);

            int quintInBassOnDownbeat = 0;
            int index = downbeats.FindIndex(db => db == chordBeatNumber);
            if (index == 0 && ConstraintsFunctions.DegreeInBass(chord, chordPossiblePitches, Degree.V)) // index == 0 -> strong constraints
                quintInBassOnDownbeat = downbeats.Count - index;

            if (nextChord != null)
            {
                double correctResolutionSum = 0;

                if (function.AddedDegree != null)
                {
                    switch (function.AddedDegree.Value)
                    {
                        case Degree.VI:
                            Pitch sixth = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.VI).Pitch;
                            correctResolutionSum += Math.Pow(Convert.ToInt32(ConstraintsFunctions.NoteIncorrectResolution(chord, nextChord, sixth, -2, -1)), beta); 
                            break;
                        case Degree.VII:
                            Pitch septim = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.VII).Pitch;
                            correctResolutionSum += Math.Pow(Convert.ToInt32(ConstraintsFunctions.NoteIncorrectResolution(chord, nextChord, septim, 1, 2)), beta);
                            break;
                        case Degree.IX:
                            septim = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.VII).Pitch;
                            Pitch ninth = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.IX).Pitch;
                            correctResolutionSum += Math.Pow(Convert.ToInt32(ConstraintsFunctions.NoteIncorrectResolution(chord, nextChord, septim, 1, 2)), beta);
                            correctResolutionSum += Math.Pow(Convert.ToInt32(ConstraintsFunctions.NoteIncorrectResolution(chord, nextChord, ninth, 1, 2)), beta);
                            break;
                        default:
                            break;
                    }
                }

                if (function.Function == Degree.V && (nextFunction.Function == Degree.I || nextFunction.Function == Degree.VI))
                {
                    Pitch third = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.III).Pitch;
                    correctResolutionSum += Math.Pow(Convert.ToInt32(ConstraintsFunctions.NoteIncorrectResolution(chord, nextChord, third, -1, -1)), beta);
                }
                double parallelQuintsSum = Math.Pow(ConstraintsFunctions.ParallelQuintsAndOctaves(chord, nextChord), beta);
                double allVoicesOneDirectionSum = Math.Pow(Convert.ToInt32(ConstraintsFunctions.AllVoicesOneDirection(chord, nextChord)), beta);


                return (voicesCrossoverSum * voicesCrossoverMultiplier) +
                       (quintInBassOnDownbeat * quintInBassOnStrongDownbeatMultiplier) +
                       (incorrectPitchesSum * incorrectPitchesInChordMultiplier) +
                       (widerThanOctaveSum * widerThanOctaveMultiplier) +
                       (correctResolutionSum * incorrectNoteResolutionMultiplier) +
                       (parallelQuintsSum * parallelQuintsMultiplier) +
                       (allVoicesOneDirectionSum * allVoicesOneDirectionMultiplier);
            }

            return (voicesCrossoverSum * voicesCrossoverMultiplier) +
                   (quintInBassOnDownbeat * quintInBassOnStrongDownbeatMultiplier) +
                   (incorrectPitchesSum * incorrectPitchesInChordMultiplier) +
                   (widerThanOctaveSum * widerThanOctaveMultiplier);
        }

        private static double CalculateStrongConstraintsForMelodicLines(Composition composition, List<int> melodicLinesIndices)
        {
            double augumentedMoveCountSum = 0;

            foreach (int index in melodicLinesIndices)
                augumentedMoveCountSum += Math.Pow(ConstraintsFunctions.AugumentedIntervalMoveCount(composition.MelodicLines[index]), beta);

            return augumentedMoveCountSum * augumentedIntervalMoveCountMultiplier;
        }

        private static double CalculatePenulitmateChordForCorrectBass(Composition composition)
        {
            Pitch[] penultimateChord = composition.GetChordAtPosition(composition.Length - 2);
            HarmonicFunction penultimateFunction = composition.Functions[^2];
            List<PitchInChord> possiblePitches = penultimateFunction.GetPitchesInFunction(composition.Key);


            // Pryma lub tercja w basie w przypadku dominanty (zdwojona jeśli 3 dźwięki)
            if (penultimateFunction.Function == Degree.V)
            {
                bool? doubled = ConstraintsFunctions.MultipliedDegree(penultimateChord, possiblePitches, Degree.I, 2);
                if (doubled.HasValue && !doubled.Value)
                    return Math.Pow(doubleFirstInBassFirstLastChordMultiplier, beta);

                if (ConstraintsFunctions.DegreeInBass(penultimateChord, possiblePitches, Degree.I) || ConstraintsFunctions.DegreeInBass(penultimateChord, possiblePitches, Degree.III))
                    return 0;

                return Math.Pow(doubleFirstInBassFirstLastChordMultiplier, beta);
            }

            return 0;
        }

    }
}
