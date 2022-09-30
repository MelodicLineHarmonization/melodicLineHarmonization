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
    public static class ModalQualityFunctions
    {
        public static int MoveOnHiddenQuintsAndOctaves(Pitch[] chord, Pitch[] nextChord)
        {
            int movesCount = 0;

            Pitch higherPitch = nextChord[0].AllPitchesOnIcuts.First();
            for (int j = 1; j < nextChord.Length; j++)
                if (Interval.IsInterval(higherPitch, nextChord[j], Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances).Item1)
                {
                    int higherMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[0].AllPitchesOnIcuts.Last(), higherPitch));
                    int lowerMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[j], nextChord[j]));

                    if (!(higherMove < 3 && lowerMove > 3))
                        movesCount++;
                }


            for (int i = 1; i < nextChord.Length; i++)
            {
                higherPitch = nextChord[i];
                for (int j = i + 1; j < nextChord.Length; j++)
                    if (Interval.IsInterval(higherPitch, nextChord[j], Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances).Item1)
                    {
                        int higherMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[i], higherPitch));
                        int lowerMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[j], nextChord[j]));

                        if (!(higherMove < 3 && lowerMove > 3))
                            movesCount++;
                    }
            }

            return movesCount;
        }

        public static int BassCorrectMovesOnAndOffThrid(MelodicLine bassLine, List<List<PitchInChord>> functions)
        {
            int correctMoves = 0;

            for (int i = 1; i < bassLine.Length - 1; i++)
            {
                PitchInChord pitch = functions[i].Find(piC => piC.DegreeInChord == Degree.III);
                if (bassLine.GetPitch(i) == pitch.Pitch)
                {
                    bool firstChord = (functions[i - 1].Find(piC => piC.DegreeInChord == Degree.I).Pitch == bassLine.GetPitch(i - 1));
                    bool secondChord = (functions[i + 1].Find(piC => piC.DegreeInChord == Degree.I).Pitch == bassLine.GetPitch(i + 1));
                    if (firstChord && secondChord)
                        correctMoves++;
                }
            }

            return correctMoves;
        }

        public static bool ChordMelodicHarmonicConnections(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord, List<PitchInChord> nextPossiblePitches)
        {
            bool hasCommonPitch = false;
            foreach (PitchInChord pInC in possiblePitches)
                foreach (PitchInChord npInC in nextPossiblePitches)
                    if (pInC.Pitch.PitchValue == npInC.Pitch.PitchValue && pInC.Pitch.Modifier == npInC.Pitch.Modifier)
                        hasCommonPitch = true;

            if (hasCommonPitch)
                return IsHarmonicConnection(chord, nextChord);
            else
                return IsMelodicConnection(chord, nextChord);
        }

        private static bool IsMelodicConnection(Pitch[] chord, Pitch[] nextChord)
        {
            List<int> moves = new();

            moves.Add(Interval.GetPitchesDifferenceInSemitones(chord[0].AllPitchesOnIcuts.Last(), nextChord[0].AllPitchesOnIcuts.Last()));
            for (int i = 1; i < chord.Length; i++)
                moves.Add(Interval.GetPitchesDifferenceInSemitones(chord[i], nextChord[i]));

            int upMoves = moves.Count(m => m > 0);
            int downMoves = moves.Count(m => m < 0);
            int noMoves = moves.Count - upMoves - downMoves;

            if (noMoves != 0)
                return true;

            if (upMoves == 3 || downMoves == 3)
                return true;

            return false;
        }

        private static bool IsHarmonicConnection(Pitch[] chord, Pitch[] nextChord)
        {
            for (int i = 0; i < chord.Length; i++)
            {
                if (Interval.GetPitchesDifferenceInSemitones(chord[i], nextChord[i]) == 0)
                    return true;
            }

            return false;
        }
    }
}
