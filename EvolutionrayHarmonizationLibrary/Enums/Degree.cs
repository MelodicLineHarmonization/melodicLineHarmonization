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
    /// Stopień, od którego budowany jest akord
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Degree
    {
        I   = 1,
        II  = 2, 
        III = 3, 
        IV  = 4, 
        V   = 5, 
        VI  = 6,
        VII = 7
    }
}
