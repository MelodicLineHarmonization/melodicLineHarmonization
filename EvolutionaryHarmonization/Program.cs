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
            //BaseComposition baseComposition = new BaseComposition();
            //baseComposition.Key = Keys.C;
            //baseComposition.PitchesAndFunctions = new List<(Pitch, HarmonicFunction)>();
            //baseComposition.PitchesAndFunctions.Add((new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C }, new HarmonicFunction { Function = HarmonicFunctions.I }));
            //baseComposition.PitchesAndFunctions.Add((new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.G }, new HarmonicFunction { Function = HarmonicFunctions.V }));


            //Composition composition = new Composition(baseComposition);
            //composition.SaveToFile("testComp.json");
            //Composition comp2 = Composition.ReadFromFile("testComp.json");

            Pitch a = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.H,
                Octave = 1
            };
            Pitch b = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.C,
                Octave = 2
            };
            Console.WriteLine(Pitch.GetPitchesDifferenceInSemitones(a, b) + " == -1");
            a = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.C,
                Octave = 1
            };
            b = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.H,
                Octave = 2
            };
            Console.WriteLine(Pitch.GetPitchesDifferenceInSemitones(a, b) + " == -23");
            a = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.H,
                Octave = 2
            };
            b = new Pitch
            {
                Modifier = Modifiers.None,
                PitchValue = Pitches.C,
                Octave = 1
            };
            Console.WriteLine(Pitch.GetPitchesDifferenceInSemitones(a, b) + " == 23");
            a = new Pitch
            {
                Modifier = Modifiers.DoubleFlat,
                PitchValue = Pitches.C,
                Octave = 2
            };
            b = new Pitch
            {
                Modifier = Modifiers.DoubleSharp,
                PitchValue = Pitches.H,
                Octave = 1
            };
            Console.WriteLine(Pitch.GetPitchesDifferenceInSemitones(a, b) + " == 1");
        }
    }
}
