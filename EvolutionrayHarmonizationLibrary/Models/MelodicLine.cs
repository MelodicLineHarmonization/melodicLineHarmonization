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
        /// <summary>
        /// Lista kolejnych nut w linii melodycznej
        /// </summary>
        public List<Pitch> Pitches { get; set; }

        /// <summary>
        /// Możliwość modyfikowania nut w linii melodycznej
        /// </summary>
        public bool IsModifiable { get; init; }
    }
}
