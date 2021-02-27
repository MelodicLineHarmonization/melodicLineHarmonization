using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;

namespace EvolutionaryHarmonization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BaseComposition baseComposition = BaseComposition.ReadFromFile("testFile.json");
            //BaseComposition baseComposition = new BaseComposition();
            //baseComposition.Key = Keys.C;
            //baseComposition.PitchesAndFunctions = new List<(Pitch, HarmonicFunction)>();
            //baseComposition.PitchesAndFunctions.Add((new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C }, new HarmonicFunction { Function = HarmonicFunctions.I }));
            //baseComposition.PitchesAndFunctions.Add((new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.G }, new HarmonicFunction { Function = HarmonicFunctions.V }));
            //baseComposition.SaveToFile("testFile.json");
        }
    }
}
