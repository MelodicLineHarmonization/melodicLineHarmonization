using EvolutionrayHarmonizationLibrary.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Model do wczytania z pliku
    /// </summary>
    public class BaseComposition
    {
        /// <summary>
        /// Klucz, w jakim utworzona jest kompozycja
        /// </summary>
        public Keys Key { get; set; }

        /// <summary>
        /// Lista dźwięków najwyższej linii melodycznej wraz z funkcjami
        /// </summary>
        public List<(Pitch, HarmonicFunction)> PitchesAndFunctions { get; set; }

        public void SaveToFile(string filePath)
        {
            string serializedClass = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, serializedClass);
        }

        public static BaseComposition ReadFromFile(string filePath)
        {
            string serializedClass = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<BaseComposition>(serializedClass);
        }
    }
}
