using EvolutionrayHarmonizationLibrary.Enums;
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
    }
}
