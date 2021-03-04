using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm
{
    /// <summary>
    /// Klasa zawierająca funkcje służące do oceny jakości stworzonej kompozycji.
    /// 1. Płynne prowadzenie głosów (alt, tenor).
    /// 2. Seksty równoległe.
    /// 3. Przeciwny ruchu sporanu i basu.
    /// 4. Przeciwny ruch na interwał doskonały (kwinta, oktawa).
    /// </summary>
    public static class QualityFunctions
    {
        private readonly static List<int> majorMinorSixthSemitones = new List<int> { 9, 8 };
        private readonly static List<int> majorMinorSixthPitchDistances = new List<int> { 2, 5 };

        private readonly static List<int> quintSemitones = new List<int> { 7 };
        private readonly static List<int> quintPitchDistances = new List<int> { 4 };

        private readonly static List<int> unisonoOctaveSemitones = new List<int> { 0 };
        private readonly static List<int> unisonoOctavePitchDistances = new List<int> { 0 };

        /// <summary>
        /// Funkcja określa płynność prowadzenie linii melodycznej.
        /// </summary>
        /// <returns>Zwracane są dwie wartości: łączna suma odległości półtonowych między kolejnymi dźwiękami 
        /// i liczba skoków przekraczająca maksymalny interwał</returns>
        // TODO Sprawdzić czy działa :)
        public static (int, int) GetMelodicLineSmooth(MelodicLine melodicLine, int maxIntervalSemitones)
        {
            int semitonesCount = 0;
            int exceedingIntervals = 0;
            for (int i = 0; i < melodicLine.Length - 1; i++)
            {
                int intervalSemitones = Pitch.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1));
                semitonesCount += intervalSemitones;
                if (intervalSemitones > maxIntervalSemitones)
                    exceedingIntervals++;
            }

            return (semitonesCount, exceedingIntervals);
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy między dwoma następującymi akordami znajdują się seksty równoległe.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        // TODO Sprawdzić czy działa :)
        public static int ParallelSixths(Pitch[] chord, Pitch[] nextChord)
        {
            int sixthsCount = 0;
            for (int i = 0; i < chord.Length; i++)
                for (int j = i + 1; j < chord.Length; j++)
                {
                    (bool isSixth, int intervalSemitones) = IsInterval(chord[i], chord[j], majorMinorSixthSemitones, majorMinorSixthPitchDistances);

                    if (isSixth)
                    {
                        (bool isNextSixth, int nextIntervalSemitones) = IsInterval(nextChord[i], nextChord[j], majorMinorSixthSemitones, majorMinorSixthPitchDistances);

                        if (isNextSixth && intervalSemitones == nextIntervalSemitones)
                            sixthsCount++;
                    }

                }

            return sixthsCount;
        }


        /// <summary>
        /// Funkcja sprawdzająca, czy ruch basu i sporanu nastąpił w przeciwnych kierunkach.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        // TODO Sprawdzić czy działa :)
        public static bool OpposedBassSopranoMove(Pitch[] chord, Pitch[] nextChord)
        {
            return OpposedVoicesMove(chord, nextChord, 0, chord.Length - 1);
        }


        /// <summary>
        /// Funkcja sprawdzająca przeciwny ruch na interwał doskonały (kwinta, oktowa, unisono).
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        // TODO Sprawdzić czy działa :)
        public static int OpposedMoveOnPerfectInterval(Pitch[] chord, Pitch[] nextChord)
        {
            int opposedMoveCount = 0;
            List<List<int>> perfectIntervalsSemitones = new List<List<int>> { quintSemitones, unisonoOctaveSemitones };
            List<List<int>> perfectIntervalsDistances = new List<List<int>> { quintPitchDistances, unisonoOctavePitchDistances };

            for (int intervalIndex = 0; intervalIndex < perfectIntervalsSemitones.Count; intervalIndex ++)
                for (int i = 0; i < nextChord.Length; i++)
                    for (int j = i + 1; j < nextChord.Length; j++)
                    {
                        (bool isInterval, int intervalSemitones) = IsInterval(nextChord[i], nextChord[j], perfectIntervalsSemitones[intervalIndex], perfectIntervalsDistances[intervalIndex]);

                        if (isInterval && OpposedVoicesMove(chord, nextChord, i, j))
                            opposedMoveCount++;

                    }

            return opposedMoveCount;
        }

        private static bool OpposedVoicesMove(Pitch[] chord, Pitch[] nextChord, int firstLineIndex, int secondLineIndex)
        {
            int firstVoiceMove = Math.Sign(Pitch.GetPitchesDifferenceInSemitones(chord[firstLineIndex], nextChord[firstLineIndex]));
            int secondVoiceMove = Math.Sign(Pitch.GetPitchesDifferenceInSemitones(chord[secondLineIndex], nextChord[secondLineIndex]));

            return firstVoiceMove + secondVoiceMove == 0;
        }

        private static (bool, int) IsInterval(Pitch first, Pitch second, List<int> acceptedSemitones, List<int> accepetedPitchesDistances)
        {
            int intervalSemitons = Math.Abs(Pitch.GetPitchesDifferenceInSemitones(first, second));
            int pitchesDistance = Math.Abs(first.PitchValue - second.PitchValue);

            bool areSemitones = false;
            foreach (int semitones in acceptedSemitones)
                if (semitones == intervalSemitons % Pitch.octaveSemitones)
                    areSemitones = true;

            bool isDistance = false;
            foreach (int distance in accepetedPitchesDistances)
                if (distance == pitchesDistance)
                    areSemitones = true;

            if (areSemitones && isDistance)
                return (true, intervalSemitons);

            return (false, -1);
        }
    }
}
