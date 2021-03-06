using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    public class PitchInChord
    {
        public Pitch Pitch { get; set; }
        public Degree DegreeInChord { get; set; }
        public int MinimumOccurencesInChord { get; set; }
        public int MaximumOccurencesInChord { get; set; }
    }
}
