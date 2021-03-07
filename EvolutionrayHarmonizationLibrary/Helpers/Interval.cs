using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Helpers
{
    public static class Interval
    {
        public readonly static int semitonesInOctave = 12;
        
        public readonly static List<int> majorMinorSixthSemitones = new List<int> { 9, 8 };
        public readonly static List<int> majorMinorSixthPitchDistances = new List<int> { 2, 5 };

        public readonly static List<int> quintSemitones = new List<int> { 7 };
        public readonly static List<int> quintPitchDistances = new List<int> { 4 };

        public readonly static List<int> unisonoOctaveSemitones = new List<int> { 0 };
        public readonly static List<int> unisonoOctavePitchDistances = new List<int> { 0 };

        public readonly static List<int> majorMinorSeptimeSemitones = new List<int> { 11, 10 };



        /// <summary>
        /// Zwraca odległość dwóch nut w półtonach.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Wartość większa od 0 oznacza, że nuta a jest wyżej od b, wartość mniejsza od zera oznacza, że nuta a jest niżej od b.</returns>
        public static int GetPitchesDifferenceInSemitones(Pitch a, Pitch b)
        {
            int firstPitchAbsoluteValue = GetPitchAbsoluteSemintones(a);
            int secondPitchAbsoluteValue = GetPitchAbsoluteSemintones(b);

            return firstPitchAbsoluteValue - secondPitchAbsoluteValue;
        }

        /// <summary>
        /// Funkcja określa, czy między dwoma dźwiękami jest zadany interwał.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="acceptedSemitones"></param>
        /// <param name="accepetedPitchesDistances"></param>
        /// <returns>Wartość boolowska określająca czy dany interwał jest i liczba półtonów w tym interwale.</returns>
        public static (bool, int) IsInterval(Pitch first, Pitch second, List<int> acceptedSemitones, List<int> accepetedPitchesDistances)
        {
            int intervalSemitons = Math.Abs(GetPitchesDifferenceInSemitones(first, second));
            int pitchesDistance = Math.Abs(first.PitchValue - second.PitchValue);

            bool areSemitones = false;
            foreach (int semitones in acceptedSemitones)
                if (semitones == intervalSemitons % semitonesInOctave)
                    areSemitones = true;

            bool isDistance = false;
            foreach (int distance in accepetedPitchesDistances)
                if (distance == pitchesDistance)
                    areSemitones = true;

            if (areSemitones && isDistance)
                return (true, intervalSemitons);

            return (false, -1);
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy między dwoma następującymi akordami znajdują się równoległe określone interwały.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns>Liczba równoległych interwałów między dwoma danymi akordami</returns>
        // TODO Sprawdzić czy działa :)
        public static int GetParallelIntervalsCount(Pitch[] chord, Pitch[] nextChord, List<int> intervaleSemitones, List<int> intervalDistances)
        {
            int intervalsCount = 0;
            for (int i = 0; i < chord.Length; i++)
                for (int j = i + 1; j < chord.Length; j++)
                {
                    (bool isInterval, int intervalSemitones) = IsInterval(chord[i], chord[j], intervaleSemitones, intervalDistances);

                    if (isInterval)
                    {
                        (bool isNextInterval, int nextIntervalSemitones) = IsInterval(nextChord[i], nextChord[j], intervaleSemitones, intervalDistances);

                        if (isNextInterval && intervalSemitones == nextIntervalSemitones)
                            intervalsCount++;
                    }

                }

            return intervalsCount;
        }

        private static int GetPitchAbsoluteSemintones(Pitch a)
        {
            int pitchOctaveSemitones = a.Octave * semitonesInOctave;
            int pitchValueSemitons = (int)a.PitchValue * 2;
            if (a.PitchValue > Pitches.E)
                pitchValueSemitons -= 1;

            int modifierSemitons = GetModifierSemitoneValue(a);
            return pitchOctaveSemitones + pitchValueSemitons + modifierSemitons;
        }

        private static int GetModifierSemitoneValue(Pitch a)
        {
            switch (a.Modifier)
            {
                case Modifiers.DoubleFlat:
                    return -2;
                case Modifiers.Flat:
                    return -1;
                case Modifiers.Sharp:
                    return 1;
                case Modifiers.DoubleSharp:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
