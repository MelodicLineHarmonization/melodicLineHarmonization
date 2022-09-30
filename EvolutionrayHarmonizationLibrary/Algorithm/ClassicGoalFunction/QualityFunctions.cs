using EvolutionrayHarmonizationLibrary.Helpers;
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
    /// <para> 1. Seksty równoległe. </para>
    /// <para> 2. Przeciwny ruchu sporanu i basu. </para>
    /// <para> 3. Przeciwny ruch na interwał doskonały (kwinta, oktawa). </para>
    /// <para> 4. Układ rozległy lepszy niż układ skupiony. </para>
    /// </summary>
    public static class QualityFunctions
    {
        /// <summary>
        /// 1. Funkcja sprawdzająca, czy między dwoma następującymi akordami znajdują się seksty równoległe.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static int ParallelSixths(Pitch[] chord, Pitch[] nextChord)
        {
            return Interval.GetParallelIntervalsCount(chord, nextChord, Interval.majorMinorSixthSemitones, Interval.majorMinorSixthPitchDistances);
        }


        /// <summary>
        /// 2. Funkcja sprawdzająca, czy ruch basu i sporanu nastąpił w przeciwnych kierunkach.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static bool ContraryBassSopranoMove(Pitch[] chord, Pitch[] nextChord)
        {
            return ContraryVoicesMove(chord, nextChord, 0, chord.Length - 1);
        }


        /// <summary>
        /// 3. Funkcja sprawdzająca przeciwny ruch na interwał doskonały (kwinta, oktowa, unisono).
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static int ContraryMoveOnPerfectInterval(Pitch[] chord, Pitch[] nextChord)
        {
            int opposedMoveCount = 0;
            List<List<int>> perfectIntervalsSemitones = new List<List<int>> { Interval.quintSemitones, Interval.unisonoOctaveSemitones };
            List<List<int>> perfectIntervalsDistances = new List<List<int>> { Interval.quintPitchDistances, Interval.unisonoOctavePitchDistances };

            for (int intervalIndex = 0; intervalIndex < perfectIntervalsSemitones.Count; intervalIndex ++)
                for (int i = 0; i < nextChord.Length; i++)
                    for (int j = i + 1; j < nextChord.Length; j++)
                    {
                        (bool isInterval, _) = Interval.IsInterval(nextChord[i], nextChord[j], perfectIntervalsSemitones[intervalIndex], perfectIntervalsDistances[intervalIndex]);

                        if (isInterval && ContraryVoicesMove(chord, nextChord, i, j))
                            opposedMoveCount++;

                    }

            return opposedMoveCount;
        }


        /// <summary>
        /// 4. Funkcja określająca rozległość układu danego akordu.
        /// </summary>
        /// <param name="chord"></param>
        /// <returns></returns>
        public static int ChordBreadth(Pitch[] chord)
        {
            int minSemitonesDistances = int.MaxValue;
            for (int i = 0; i < chord.Length - 1; i++)
            {
                int pitchesDistance = Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[i], chord[i + 1]));
                if (pitchesDistance < minSemitonesDistances)
                    minSemitonesDistances = pitchesDistance;
            }

            return minSemitonesDistances;
        }

        private static bool ContraryVoicesMove(Pitch[] chord, Pitch[] nextChord, int firstLineIndex, int secondLineIndex)
        {
            int firstVoiceMove = Math.Sign(Interval.GetPitchesDifferenceInSemitones(chord[firstLineIndex], nextChord[firstLineIndex]));
            int secondVoiceMove = Math.Sign(Interval.GetPitchesDifferenceInSemitones(chord[secondLineIndex], nextChord[secondLineIndex]));

            return firstVoiceMove + secondVoiceMove == 0;
        }
    }
}
