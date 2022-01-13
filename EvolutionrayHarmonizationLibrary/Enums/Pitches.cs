using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Enums
{
    /// <summary>
    /// Wysokości dźwięków (bez modyfikatorów)
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Pitches
    {
        C = 1,
        D = 2,
        E = 3,
        F = 4,
        G = 5,
        A = 6,
        H = 7
    }
}
