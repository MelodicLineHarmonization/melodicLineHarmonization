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
        private static readonly int chordBreadthMultiplier = 5;

        private static readonly int septimMoveMultiplier = 10;
        private static readonly int melodicLineSmoothMultiplier = 10;

        private static readonly int followingOnQuintMultiplier = 10;
        private static readonly int doubleQuintNotInBassMultiplier = 10;
        private static readonly int moreThenTwoVoicesWithoutMoveMultiplier = 10;
        private static readonly int voicesNotInAppropriateRangeMultiplier = 10;

        private static readonly int augumentedIntervalMoveCountMultiplier = 10;

        private static readonly int voicesCrossoverMultiplier = 10;
        private static readonly int incorrectPitchesInChordMultiplier = 10;
        private static readonly int widerThanOctaveMultiplier = 10;
        private static readonly int incorrectNoteResolutionMultiplier = 10;
        private static readonly int parallelQuintsMultiplier = 10;
        private static readonly int allVoicesOneDirectionMultiplier = 10;

        public static double CalculateCompositionScore(Composition composition)
        {
            // suma po wszystkich akordach + sprawdzić pierwszy i ostatni akord (dwojenie prymy i pryma w basie)
            throw new NotImplementedException();
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

        private static double CalculateWeakConstraintsForChords(Keys key, Pitch[] chord, HarmonicFunction function, Pitch[] nextChord = null, HarmonicFunction nextFunction = null)
        {
            List<PitchInChord> chordPossiblePitches = function.GetPitchesInFunction(key);

            int voicesNotInAppropriateRange = ConstraintsFunctions.VoicesNotInAppropriateRange(chord);
            bool? doubleQuintsInBass = ConstraintsFunctions.DoubledDegreeInBass(chord, chordPossiblePitches, Degree.V);
            int doubleQuintsNotInBass = doubleQuintsInBass.HasValue ? Convert.ToInt32(!doubleQuintsInBass.Value) : 0;

            if (nextChord != null)
            {
                List<PitchInChord> nextChordPossiblePitches = nextFunction.GetPitchesInFunction(key);
                int followingOnQuints = Convert.ToInt32(ConstraintsFunctions.FollowingChordsOnQuint(chord, chordPossiblePitches, nextChord, nextChordPossiblePitches));
                int moreThenTwoVoicesWithoutMove = ConstraintsFunctions.AtLeastTwoVoicesMove(chord, nextChord);

                return followingOnQuints * followingOnQuintMultiplier +
                       doubleQuintsNotInBass * doubleQuintNotInBassMultiplier +
                       moreThenTwoVoicesWithoutMove * moreThenTwoVoicesWithoutMoveMultiplier +
                       voicesNotInAppropriateRange * voicesNotInAppropriateRangeMultiplier;
            }

            return doubleQuintsNotInBass * doubleQuintNotInBassMultiplier +
                   voicesNotInAppropriateRange * voicesNotInAppropriateRangeMultiplier;
        }

        private static double CaculateWeakConstraintsForMelodicLines(Composition composition, List<int> septimeMoveMelodicLinesIndices, List<int> smoothMelodicLinesIndices)
        {
            int septimeMoveSum = 0;
            int melodicLineSmoothSum = 0;

            foreach (int index in septimeMoveMelodicLinesIndices)
                septimeMoveSum += ConstraintsFunctions.SeptimeMove(composition.MelodicLines[index]);

            foreach (int index in smoothMelodicLinesIndices)
                melodicLineSmoothSum += ConstraintsFunctions.GetMelodicLineSmooth(composition.MelodicLines[index]).Item1;

            return septimeMoveSum * septimMoveMultiplier +
                   melodicLineSmoothSum * melodicLineSmoothMultiplier;
        }

        private static double CalculateStrongConstraintsForChords(Keys key, Pitch[] chord, HarmonicFunction function, Pitch[] nextChord = null, HarmonicFunction nextFunction = null)
        {
            List<PitchInChord> chordPossiblePitches = function.GetPitchesInFunction(key);
            int voicesCrossoverSum = ConstraintsFunctions.VoicesCrossover(chord);
            int incorrectPitchesSum = ConstraintsFunctions.IncorrectPitchesInChord(chord, chordPossiblePitches);
            int widerThanOctaveSum = ConstraintsFunctions.WiderThanOctaveSpread(chord);
            if (nextChord != null)
            {
                int correctResolutionSum = 0;
                if (function.Function == Degree.V)
                {
                    Pitch third = chordPossiblePitches.Find(piC => piC.DegreeInChord == Degree.III).Pitch;
                    correctResolutionSum = Convert.ToInt32(ConstraintsFunctions.NoteCorrectResolution(chord, nextChord, third, 1, 1));
                }
                int parallelQuintsSum = ConstraintsFunctions.ParallelQuintsAndOctaves(chord, nextChord);
                int allVoicesOneDirectionSum = Convert.ToInt32(ConstraintsFunctions.AllVoicesOneDirection(chord, nextChord));


                return voicesCrossoverSum * voicesCrossoverMultiplier +
                       incorrectPitchesSum * incorrectPitchesInChordMultiplier +
                       widerThanOctaveSum * widerThanOctaveMultiplier +
                       correctResolutionSum * incorrectNoteResolutionMultiplier +
                       parallelQuintsSum * parallelQuintsMultiplier +
                       allVoicesOneDirectionSum * allVoicesOneDirectionMultiplier;
            }

            return voicesCrossoverSum * voicesCrossoverMultiplier +
                   incorrectPitchesSum * incorrectPitchesInChordMultiplier +
                   widerThanOctaveSum * widerThanOctaveMultiplier;
        }

        private static double CalculateStrongConstraintsForMelodicLines(Composition composition, List<int> melodicLinesIndices)
        {
            int augumentedMoveCountSum = 0;

            foreach (int index in melodicLinesIndices)
                augumentedMoveCountSum += ConstraintsFunctions.AugumentedIntervalMoveCount(composition.MelodicLines[index]);

            return augumentedMoveCountSum * augumentedIntervalMoveCountMultiplier;
        }
    }
}
