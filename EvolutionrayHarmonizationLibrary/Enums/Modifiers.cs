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
    /// Modyfikatory nut (krzyżyk, bemol, kasownik)
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Modifiers
    {
        DoubleFlat = 0,
        Flat = 1,
        Natural = 2,
        None = 3,
        Sharp = 4,
        DoubleSharp = 5
    }
}
