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

        /// <summary>
        /// Długość kompozycji.
        /// </summary>
        public int Length => Functions.Count;
        
        
        public Composition() { }
        public Composition(BaseComposition baseComposition)
        {
            Key = baseComposition.Key;
            List<Pitch> pitches = new();
            MelodicLines = new();
            Functions = new();

            foreach((Pitch, HarmonicFunction) el in baseComposition.PitchesAndFunctions)
            {
                pitches.Add(el.Item1.Copy());
                Functions.Add(el.Item2.Copy());
            }

            MelodicLines.Add(new MelodicLine(pitches, false));
        }


        /// <summary>
        /// Funkcja zwraca pojednyczy akord (pion) z kompozycji.
        /// </summary>
        /// <param name="index">Numer akordu w kompozycji liczony od 0.</param>
        /// <returns></returns>
        public Pitch[] GetChordAtPosition(int index)
        {
            if (index > Length)
                throw new ArgumentException("Index too large.");

            Pitch[] pitches = new Pitch[MelodicLines.Count];
            for (int i = 0; i < MelodicLines.Count; i++)
                pitches[i] = MelodicLines[i].GetPitch(index);

            return pitches;
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
                MelodicLines = new(),
                Functions = new()
            };

            foreach (MelodicLine line in MelodicLines)
                composition.MelodicLines.Add(line.Copy());

            foreach (HarmonicFunction function in Functions)
                composition.Functions.Add(function.Copy());
            
            return composition;
        }

        public static Composition ReadFromFile(string filePath)
        {
            string serializedClass = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Composition>(serializedClass);
        }
    }
}
