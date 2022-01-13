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
        public string Name { get; set; }

        /// <summary>
        /// Klucz, w jakim utworzona jest kompozycja
        /// </summary>
        public Keys Key { get; set; }

        /// <summary>
        /// Metrum
        /// </summary>
        public TimeSignature TimeSignature { get; set; }

        /// <summary>
        /// Lista dźwięków najwyższej linii melodycznej wraz z funkcjami
        /// </summary>
        public List<(Pitch pitch, HarmonicFunction function)> PitchesAndFunctions { get; set; }

        /// <summary>
        /// Indeks podanego głosu
        /// </summary>
        public int VoiceIndex { get; set; }

        /// <summary>
        /// Tablica wskazująca mocne części w takcie pod względem istotności.
        /// Wartość pod indeksem 0 jest najmocniejsza, wartość pod ostatnim indeksem najsłabsza.
        /// </summary>
        public List<double> Downbeats { get; set; } = new List<double> { 1 };

        public int Length
        {
            get => PitchesAndFunctions.Count;
        }

        public void SaveToFile(string filePath)
        {
            string serializedClass = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, serializedClass);
        }

        public List<HarmonicFunction> GetFunctions()
        {
            List<HarmonicFunction> functions = new();
            foreach ((Pitch, HarmonicFunction) pitchAndFunction in PitchesAndFunctions)
                functions.Add(pitchAndFunction.Item2.Copy());

            return functions;
        }

        public List<Pitch> GetPitches()
        {
            List<Pitch> pitches = new();
            foreach ((Pitch, HarmonicFunction) pitchAndFunction in PitchesAndFunctions)
                pitches.Add(pitchAndFunction.Item1.Copy());

            return pitches;
        }

        public static BaseComposition ReadFromFile(string filePath)
        {
            string serializedClass = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<BaseComposition>(serializedClass);
        }
    }
}
