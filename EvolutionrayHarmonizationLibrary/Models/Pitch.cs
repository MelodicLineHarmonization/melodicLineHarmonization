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
        /// Numer oktawy, w której dźwięk się znajduje.
        /// Oktawa subkontra oznaczona wartością 1.
        /// Wartość 0 oznacza brak oktawy (dowolna oktawa).
        /// </summary>
        public int Octave { get; set; }


        public Pitch Copy()
        {
            return new Pitch
            {
                PitchValue = PitchValue,
                Modifier = Modifier,
                Octave = Octave
            };
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

        public static int GetPitchValueDistance(Pitch first, Pitch second)
        {
            int[] octaves = new int[2] { first.Octave, second.Octave };
            Pitches[] values = new Pitches[2] { first.PitchValue, second.PitchValue };

            int higherIndex = octaves[0] > octaves[1] ? 0 : octaves[0] < octaves[1] ? 1 : values[0] > values[1] ? 0 : 1;
            int lowerIndex = higherIndex == 0 ? 1 : 0;

            int octaveDifference = octaves[higherIndex] - octaves[lowerIndex];
            int pitchesDifference = values[higherIndex] - values[lowerIndex];
            if (values[higherIndex] < values[lowerIndex])
            {
                pitchesDifference = pitchesCount + pitchesDifference;
                octaveDifference--;
            }

            return octaveDifference * pitchesCount + pitchesDifference;
        }

        public static bool operator >(Pitch left, Pitch right)
        {
            int difference = Interval.GetPitchesDifferenceInSemitones(left, right);
            if (difference > 0)
                return true;

            return false;
        }

        public static bool operator <(Pitch left, Pitch right)
        {
            int difference = Interval.GetPitchesDifferenceInSemitones(left, right);
            if (difference < 0)
                return true;

            return false;
        }

        public static bool operator ==(Pitch left, Pitch right)
        {
            if (left.Modifier == right.Modifier && left.PitchValue == right.PitchValue && (left.Octave == right.Octave || left.Octave == 0 || right.Octave == 0))
                return true;

            return false;
        }

        public static bool operator !=(Pitch left, Pitch right)
        {
            return !(left == right);
        }

        public static bool operator >=(Pitch left, Pitch right)
        {
            int difference = Interval.GetPitchesDifferenceInSemitones(left, right);
            if (difference >= 0)
                return true;

            return false;
        }

        public static bool operator <=(Pitch left, Pitch right)
        {
            int difference = Interval.GetPitchesDifferenceInSemitones(left, right);
            if (difference <= 0)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this == (Pitch)obj;
        }

        public override int GetHashCode()
        {
            return Octave.GetHashCode() + Modifier.GetHashCode() + PitchValue.GetHashCode();
        }
    }
}
