using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Metrum
    /// </summary>
    public struct TimeSignature
    {
        /// <summary>
        /// Jednostka metrum
        /// </summary>
        public Values Denominator { get; set; }
        /// <summary>
        /// Ilość jednostek w metrum
        /// </summary>
        public int Numerator { get; set; }

        public static bool operator == (TimeSignature left, TimeSignature right)
        {
            return (left.Denominator == right.Denominator && left.Numerator == right.Numerator);
        }

        public static bool operator != (TimeSignature left, TimeSignature right)
        {
            return !(left == right);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override bool Equals(object obj)
        {
            return obj is TimeSignature signature &&
                   Denominator == signature.Denominator &&
                   Numerator == signature.Numerator;
        }
    }

}
