﻿using EvolutionrayHarmonizationLibrary.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Klasa reprezetnująca linię melodyczną
    /// </summary>
    public class MelodicLine
    {
        public static readonly List<(Pitch Min, Pitch Max)> VoicesRange = new()
        {
            (new Pitch { Modifier = Modifiers.None, Octave = 5, PitchValue = Pitches.C }, new Pitch { Modifier = Modifiers.None, Octave = 6, PitchValue = Pitches.A }),
            (new Pitch { Modifier = Modifiers.None, Octave = 4, PitchValue = Pitches.G }, new Pitch { Modifier = Modifiers.None, Octave = 6, PitchValue = Pitches.C }),
            (new Pitch { Modifier = Modifiers.None, Octave = 4, PitchValue = Pitches.C }, new Pitch { Modifier = Modifiers.None, Octave = 5, PitchValue = Pitches.G }),
            (new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.E }, new Pitch { Modifier = Modifiers.None, Octave = 5, PitchValue = Pitches.C })
        };   

        /// <summary>
        /// Lista kolejnych nut w linii melodycznej.
        /// </summary>
        [JsonProperty]
        private readonly List<Pitch> pitches;

        /// <summary>
        /// Możliwość modyfikowania nut w linii melodycznej.
        /// </summary>
        public bool IsModifiable { get; init; }

        /// <summary>
        /// Liczba nut w linii melodycznej.
        /// </summary>
        public int Length => pitches.Count;
        
        public MelodicLine(List<Pitch> pitches, bool isModifiable)
        {
            this.pitches = pitches;
            IsModifiable = isModifiable;
        }

        public Pitch GetPitch(int index)
        {
            if (index >= pitches.Count)
                throw new ArgumentException($"Pitches count in melodic line is {pitches.Count}");
            
            return pitches[index];
        }

        public void SetPitch(int index, Pitch pitch)
        {
            if (!IsModifiable)
                throw new InvalidOperationException("This melodic line cannot be modified.");

            if (index >= pitches.Count)
                throw new ArgumentException($"Pitches count in melodic line is {pitches.Count}");

            pitches[index] = pitch;
        }

        public MelodicLine Copy()
        {
            MelodicLine line = new MelodicLine(new List<Pitch>(pitches.Count), IsModifiable);

            foreach (Pitch pitch in pitches)
                line.pitches.Add(pitch.Copy());

            return line;
        }
    }
}
