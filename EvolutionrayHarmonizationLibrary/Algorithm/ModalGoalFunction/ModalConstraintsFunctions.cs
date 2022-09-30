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
    public static class ModalConstraintsFunctions
    {
        public static int VoicesCrossover(Pitch[] chord)
        {
            int crossedVoices = 0;

            foreach (Pitch p in chord[0].AllPitchesOnIcuts)
            {
                int differenceInSemitones = Interval.GetPitchesDifferenceInSemitones(p, chord[1]);

                if (differenceInSemitones < 0)
                    crossedVoices++;
            }

            for (int i = 1; i < chord.Length - 1; i++)
            {
                int differenceInSemitones = Interval.GetPitchesDifferenceInSemitones(chord[i], chord[i + 1]);

                if (differenceInSemitones < 0)
                    crossedVoices++;
            }

            return crossedVoices;
        }


        //dodać testy?
        public static int VoicesCrossoverBetweenChords(Pitch[] chord, Pitch[] nextChord)
        {
            int crossedVoices = 0;

            int differenceInSemitones = Interval.GetPitchesDifferenceInSemitones(chord[0].AllPitchesOnIcuts.Last(), nextChord[1]);

            if (differenceInSemitones < 0)
                crossedVoices++;

            for (int i = 1; i < chord.Length - 1; i++)
            {
                differenceInSemitones = Interval.GetPitchesDifferenceInSemitones(chord[i], nextChord[i + 1]);

                if (differenceInSemitones < 0)
                    crossedVoices++;
            }

            return crossedVoices;
        }

        public static int ParallelQuintsAndOctaves(Pitch[] chord, Pitch[] nextChord)
        {
            int quintSum = Interval.GetParallelIntervalsCount(chord, nextChord, Interval.quintSemitones, Interval.quintPitchDistances);
            int octaveSum = Interval.GetParallelIntervalsCount(chord, nextChord, Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances);
            return quintSum + octaveSum;
        }

        /// <summary>
        /// W skrajnych głosach dopuszczalne (do tablicy pitches tylko sopran i bas) w środkowych głosach niedopuszczalne (w tablicach pozostałe kombinacje (sopran i alt, sopran i tenor, alt i tenor, alt i bas, tenor i bas)
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static int AntiparallelQuintsAndOctaves(Pitch[] chord, Pitch[] nextChord)
        {
            int quintSum = Interval.GetAntiparallelIntervalsCount(chord, nextChord, Interval.quintSemitones, Interval.quintPitchDistances);
            int octaveSum = Interval.GetAntiparallelIntervalsCount(chord, nextChord, Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances);
            return quintSum + octaveSum;
        }

        public static int AntiparallelOctaves(Pitch[] chord, Pitch[] nextChord)
        {
            int octaveSum = Interval.GetAntiparallelIntervalsCount(chord, nextChord, Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances);
            return octaveSum;
        }

        public static bool AltTenorWiderThanOctaveSpread(Pitch[] chord)
        {
            bool exceeding = false;

            if (Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[1], chord[2])) > Interval.semitonesInOctave)
                exceeding = true;

            return exceeding;
        }

        public static int AltSopranoWiderThanOctaveSpread(Pitch[] chord)
        {
            int exceedingIntervals = 0;

            foreach (Pitch p in chord[0].AllPitchesOnIcuts)
                if (Math.Abs(Interval.GetPitchesDifferenceInSemitones(p, chord[1])) > Interval.semitonesInOctave)
                    exceedingIntervals++;

            return exceedingIntervals;
        }

        public static int AugumentedIntervalMoveCount(MelodicLine melodicLine)
        {
            int augumentedCount = 0;
            for (int i = 0; i < melodicLine.Length - 1; i++)
            {
                int semitonesMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));
                int pitchValueDistanve = Pitch.GetPitchValueDistance(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1));

                if (pitchValueDistanve > 2) // at least quart
                {
                    if (pitchValueDistanve * 2 <= semitonesMove)
                        augumentedCount++;
                }
                else // maximum third
                {
                    if (pitchValueDistanve * 2 < semitonesMove)
                        augumentedCount++;
                }

            }

            return augumentedCount;
        }

        public static int QuartQuintMoveInOneDirection(MelodicLine melodicLine)
        {
            int totalMoves = 0;

            List<int> moves = new List<int>();
            for (int i = 0; i < melodicLine.Length - 1; i++)
                moves.Add(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));

            for (int i = 0; i < moves.Count - 1; i++)
            {
                if (Math.Sign(moves[i]) == Math.Sign(moves[i + 1]))
                {
                    if ((Interval.quartSemitones.Contains(Math.Abs(moves[i])) && Interval.quartSemitones.Contains(Math.Abs(moves[i + 1]))) ||
                        (Interval.quintSemitones.Contains(Math.Abs(moves[i])) && Interval.quintSemitones.Contains(Math.Abs(moves[i + 1]))))
                        totalMoves++;
                }
            }

            return totalMoves;
        }

        public static bool IsChordInInversion(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            return !DegreeInBass(chord, possiblePitches, Degree.I);
        }

        public static int MelodicLineMaxMove(MelodicLine melodicLine, int maxMoveInSemitones)
        {
            int biggerThenMaxMove = 0;
            List<int> moves = new();
            for (int i = 0; i < melodicLine.Length - 1; i++)
                if (Math.Abs(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1))) > maxMoveInSemitones)
                    biggerThenMaxMove++;

            return biggerThenMaxMove;
        }

        //Jeśli akord sekstowy (pierwszy przewrót)
        public static bool? CorrectDoubledThird(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            if (!DegreeInBass(chord, possiblePitches, Degree.III))
                throw new ArgumentException("Chord has not third in bass.");

            bool? doubleThird = MultipliedDegree(chord, possiblePitches, Degree.III, 2);
            if (!doubleThird.HasValue || !doubleThird.Value)
                return true;

            if (HarmonicFunction.IsChordMinor(possiblePitches))
            {
                if (chord[0].PitchValue == chord[^1].PitchValue && chord[0].Modifier == chord[^1].Modifier)
                    return false;

                if (chord[1].PitchValue == chord[^1].PitchValue && chord[1].Modifier == chord[^1].Modifier)
                    return false;

                return true;
            }

            if (HarmonicFunction.IsChordMajor(possiblePitches))
            {
                bool? hasDoubleThird = MultipliedDegree(chord[1..], possiblePitches, Degree.III, 2);
                return !hasDoubleThird.HasValue || !hasDoubleThird.Value;
            }

            return null;
        }

        public static int BassCorrectMovesThirds(MelodicLine bassLine, List<List<PitchInChord>> functions)
        {
            int incorrectMoves = 0;
            for (int i = 0; i < bassLine.Length - 2; i++)
            {
                PitchInChord pitch = functions[i].Find(piC => piC.DegreeInChord == Degree.III);
                if (bassLine.GetPitch(i) == pitch.Pitch)
                {
                    int firstMove = Interval.GetPitchesDifferenceInSemitones(bassLine.GetPitch(i), bassLine.GetPitch(i + 1));
                    if (Interval.quartSemitones.Contains(Math.Abs(firstMove)) &&
                        Math.Sign(Interval.GetPitchesDifferenceInSemitones(bassLine.GetPitch(i + 1), bassLine.GetPitch(i + 2))) + Math.Sign(firstMove) != 0)
                        incorrectMoves++;
                }
            }

            return incorrectMoves;
        }

        //Jeśli akord kwartsekstowy (drugi przewrót)
        public static bool IsQuintCorrectDoubled(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            if (!DegreeInBass(chord, possiblePitches, Degree.V))
                throw new ArgumentException("Chord has not quint in bass.");

            bool? multiplied = MultipliedDegree(chord, possiblePitches, Degree.V, 2);

            return !multiplied.HasValue || multiplied.Value;
        }

        public static int BassCorrectMovesQuints(MelodicLine bassLine, List<List<PitchInChord>> functions)
        {
            int incorrectMoves = 0;
            PitchInChord pitch = functions[0].Find(piC => piC.DegreeInChord == Degree.V);
            if (bassLine.GetPitch(0) == pitch.Pitch)
                if (Interval.GetPitchesDifferenceInSemitones(bassLine.GetPitch(0), bassLine.GetPitch(1)) != 0)
                    incorrectMoves++;

            for (int i = 1; i < bassLine.Length - 1; i++)
            {
                pitch = functions[i].Find(piC => piC.DegreeInChord == Degree.V);
                if (bassLine.GetPitch(i) == pitch.Pitch)
                {
                    int firstMove = Interval.GetPitchesDifferenceInSemitones(bassLine.GetPitch(i - 1), bassLine.GetPitch(i));
                    int secondMove = Interval.GetPitchesDifferenceInSemitones(bassLine.GetPitch(i), bassLine.GetPitch(i + 1));
                    if (firstMove != 0 || secondMove != 0)
                        incorrectMoves++;
                }
            }

            return incorrectMoves;
        }

        public static bool IsMoveChord(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            if (!DegreeInBass(chord, possiblePitches, Degree.I))
                return true;

            if (!DegreeInMelody(chord, possiblePitches, Degree.I))
                return true;

            return false;
        }

        //Akord septymowy
        public static bool AugumentedQuintInChord(List<PitchInChord> possiblePitches)
        {
            for (int i = 0; i < possiblePitches.Count - 2; i++)
            {
                int semitonesMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(possiblePitches[i].Pitch, possiblePitches[i + 2].Pitch));
                int pitchValueDistanve = Pitch.GetPitchValueDistance(possiblePitches[i].Pitch, possiblePitches[i + 2].Pitch);

                if (pitchValueDistanve > 2) // at least quart
                {
                    if (pitchValueDistanve * 2 <= semitonesMove)
                        return true;
                }
                else // maximum third
                {
                    if (pitchValueDistanve * 2 < semitonesMove)
                        return true;
                }
            }

            return false;
        }

        public static bool IsSepitmPrepared(Pitch[] chord, Pitch[] nextChord, List<PitchInChord> nextPossiblePitches)
        {
            PitchInChord septimPitch = nextPossiblePitches.Find(piC => piC.DegreeInChord == Degree.VII);
            int idx = Array.IndexOf(nextChord, septimPitch.Pitch);

            return chord[idx] == nextChord[idx];
        }

        public static bool IsSeptimInAltOrTenor(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            PitchInChord septimPitch = possiblePitches.Find(piC => piC.DegreeInChord == Degree.VII);

            return chord[1] == septimPitch.Pitch || chord[2] == septimPitch.Pitch;
        }

        public static bool SeptimCorrectResolution(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord)
        {
            PitchInChord septimPitch = possiblePitches.Find(piC => piC.DegreeInChord == Degree.VII);
            int idx = Array.IndexOf(chord, septimPitch.Pitch);

            if (DegreeInBass(chord, possiblePitches, Degree.III) && !NoteIncorrectResolution(chord, nextChord, septimPitch.Pitch, 0, 0)) //jeśli septyma została w pierwszym przewrocie
                return true;

            return !NoteIncorrectResolution(chord, nextChord, septimPitch.Pitch, 1, 2);
        }

        //Pomocnicze
        public static bool? MultipliedDegree(Pitch[] chord, List<PitchInChord> possiblePitches, Degree degree, int count)
        {
            if (possiblePitches.Count > 3)
                return null;

            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == degree);
            int degreeCount = chord.Count(p => p == pitch.Pitch);

            return degreeCount >= count;
        }

        public static bool DegreeInBass(Pitch[] chord, List<PitchInChord> possiblePitches, Degree degree)
        {
            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == degree);

            return chord[^1] == pitch.Pitch;
        }

        public static bool DegreeInMelody(Pitch[] chord, List<PitchInChord> possiblePitches, Degree degree)
        {
            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == degree);

            return chord[0] == pitch.Pitch;
        }

        public static bool NoteIncorrectResolution(Pitch[] chord, Pitch[] nextChord, Pitch pitchToResolution, int minSemitoneMove, int maxSemitoneMove)
        {
            int pitchIndex = Array.IndexOf(chord, pitchToResolution);
            if (pitchIndex == -1)
                return true;

            int semitoneDifference = Interval.GetPitchesDifferenceInSemitones(chord[pitchIndex], nextChord[pitchIndex]);
            if (semitoneDifference <= maxSemitoneMove && semitoneDifference >= minSemitoneMove)
                return false;

            return true;
        }
    }
}
