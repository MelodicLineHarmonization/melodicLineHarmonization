using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Kompozycja utworzona przez SI
    /// </summary>
    public class Composition
    {

        /// <summary>
        /// Klucz, w jakim utworzona jest kompozycja
        /// </summary>
        public Keys Key { get; set; }

        /// <summary>
        /// Lista linii melodycznych kompozycji
        /// </summary>
        public List<MelodicLine> MelodicLines { get; init; }

        /// <summary>
        /// Lista zadanych funkcji
        /// </summary>
        public List<HarmonicFunction> Functions { get; init; } 

        public Composition(BaseComposition baseComposition)
        {
            Key = baseComposition.Key;
            List<Pitch> pitches = new List<Pitch>();
            MelodicLines = new List<MelodicLine>();
            Functions = new List<HarmonicFunction>();

            foreach((Pitch, HarmonicFunction) el in baseComposition.PitchesAndFunctions)
            {
                pitches.Add(el.Item1);
                Functions.Add(el.Item2);
            }

            MelodicLines.Add(new MelodicLine { IsModifiable = false, Pitches = pitches });
        }
    }
}
