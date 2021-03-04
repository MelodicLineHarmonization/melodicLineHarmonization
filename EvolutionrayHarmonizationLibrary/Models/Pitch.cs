using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca Wyokość dźwięku
    /// </summary>
    public class Pitch
    {
        public readonly static int octaveSemitones = 12;
        public readonly static int[] pitchesValues = Enum.GetValues(typeof(Pitches)).Cast<int>().ToArray();
        public readonly static int pitchesCount = pitchesValues.Length;
        public readonly static int minPitchValue = pitchesValues.Min();
        public readonly static int maxPitchValue = pitchesValues.Max();

        /// <summary>
        /// Wysokość dźwięku bez modyfikatora
        /// </summary>
        public Pitches PitchValue { get; set; }

        /// <summary>
        /// Modyfikator wysokości dźwięku
        /// </summary>
        public Modifiers Modifier { get; set; }

        /// <summary>
        /// Numer oktawy, w której dźwięk się znajduje
        /// </summary>
        public int? Octave { get; set; }


        public Pitch Copy()
        {
            return new Pitch
            {
                PitchValue = PitchValue,
                Modifier = Modifier,
                Octave = Octave
            };
        }

        public static Pitch GetRandom(int minOctave, int maxOctave)
        {
            Pitch p = new Pitch
            {
                Octave = RandomSingleton.Next(minOctave, maxOctave + 1),
                PitchValue = (Pitches)pitchesValues[RandomSingleton.Next(0, pitchesCount)],
                Modifier = Modifiers.None
            };

            return p;
        }

        public void ToKey(Keys key)
        {
            (List<(Pitches, Modifiers)> signs, _, _) = KeyConverter.KeyToSigns(key);

            foreach ((Pitches, Modifiers) sign in signs)
                if (sign.Item1 == PitchValue)
                {
                    Modifier = sign.Item2;
                    break;
                }
        }

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

        private static int GetPitchAbsoluteSemintones(Pitch a)
        {
            int pitchOctaveSemitones = a.Octave.Value * octaveSemitones;
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
