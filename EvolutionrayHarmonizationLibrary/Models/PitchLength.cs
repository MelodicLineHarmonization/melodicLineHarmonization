using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    public class PitchLength
    {
        public Values LengthValue { get; init; }

        public bool WithDot { get; init; } = false;

        public double GetRelativeDuration(Values denominator)
        {
            double realtiveDuration = (int)denominator / (int)LengthValue;
            return realtiveDuration * (WithDot ? 1.5 : 1);
        }
    }
}
