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
    }
}
