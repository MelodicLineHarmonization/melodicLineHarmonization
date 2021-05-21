using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Values
    {
        WholeNote           = 1,
        HalfNote            = 2,
        QuarterNote         = 4,
        EigthNote           = 8,
        SixteenthNote       = 16,
        ThirtySecondNote    = 32
    }
}
