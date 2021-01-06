using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca Wyokość dźwięku
    /// </summary>
    public class Pitch
    {
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
