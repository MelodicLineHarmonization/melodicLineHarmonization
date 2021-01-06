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
        public Key Key { get; set; }

        /// <summary>
        /// Lista linii melodycznych kompozycji
        /// </summary>
        public List<MelodicLine> MelodicLines { get; set; }

        /// <summary>
        /// Lista zadanych funkcji
        /// </summary>
        public List<HarmonicFunction> Functions { get; set; } 
    }
}
