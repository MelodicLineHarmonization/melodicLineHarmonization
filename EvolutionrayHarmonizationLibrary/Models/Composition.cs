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
    /// Kompozycja utworzona przez SI
    /// </summary>
    public class Composition
    {

        /// <summary>
        /// Klucz, w jakim utworzona jest kompozycja
        /// </summary>
        public Keys Key { get; set; }

        /// <summary>
        /// Lista linii melodycznych kompozycji.
        /// Pod indeksem 0 zapisana partia sopranu,
        /// pod indeksem 1 zapisana partia altu,
        /// pod indeksem 2 zapisana partia tenoru,
        /// pod indeksem 3 zaspiana partia basu.
        /// </summary>
        public List<MelodicLine> MelodicLines { get; set; }

        /// <summary>
        /// Lista zadanych funkcji
        /// </summary>
        public List<HarmonicFunction> Functions { get; set; } 
        
        
        public Composition() { }
        public Composition(BaseComposition baseComposition)
        {
            Key = baseComposition.Key;
            List<Pitch> pitches = new List<Pitch>();
            MelodicLines = new List<MelodicLine>();
            Functions = new List<HarmonicFunction>();

            foreach((Pitch, HarmonicFunction) el in baseComposition.PitchesAndFunctions)
            {
                pitches.Add(el.Item1);
                Functions.Add(el.Item2);
            }

            MelodicLines.Add(new MelodicLine(pitches, false));
        }

        public void SaveToFile(string filePath)
        {
            string serializedClass = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, serializedClass);
        }

        public Composition Copy()
        {
            Composition composition = new Composition
            {
                Key = Key,
                MelodicLines = new List<MelodicLine>(4),
                Functions = new List<HarmonicFunction>()
            };

            foreach (MelodicLine line in MelodicLines)
                composition.MelodicLines.Add(line.Copy());

            foreach (HarmonicFunction function in Functions)
                composition.Functions.Add(function.Copy());
            
            return composition;
        }
    }
}
