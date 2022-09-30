using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryHarmonization
{
    public static class ModalHarmonizationExamples
    {
        public static readonly List<Func<BaseComposition>> AllExamplesCreateFunctions = new()
        {
            ModalHarmonizationKyrieXI,
            ModalHarmonizationGloriaII_1,
            ModalHarmonizationGloriaII_2,
            ModalHarmonizationSanctusII,
            ModalHarmonizationAgnusII,
            ModalHarmonizationKyrieXIII,
            ModalHarmonizationKyrieIV,
            ModalHarmonizationKyrieIX,
            ModalHarmonizationAgnusXI,
            ModalHarmonizationAgnusXIII,
            ModalHarmonizationSanctusXIV
        };

        #region grupa1
        public static BaseComposition ModalHarmonizationKyrieXI()
        {
            Keys compositionKey = Keys.C;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.VII, ChangedDegrees = new() { (Degree.I, false) } }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.II }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                }
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "KyrieXI", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 8 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationGloriaII_2()
        {
            Keys compositionKey = Keys.C;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.VII, ChangedDegrees = new() { (Degree.I, false) } }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.VII, ChangedDegrees = new() { (Degree.I, false) } }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.III, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.III, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.II }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "GloriaII_2", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 9 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationGloriaII_1()
        {
            Keys compositionKey = Keys.C;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.V, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.V, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.V, ChangedDegrees = new() { (Degree.III, false) } }),
                (new HarmonicFunction() { Function = Degree.II }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } }
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "GloriaII_1", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 10 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationSanctusII()
        {
            Keys compositionKey = Keys.D;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.II }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "SanctusII", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        #endregion

        #region grupa2
        public static BaseComposition ModalHarmonizationKyrieIV()
        {
            Keys compositionKey = Keys.h;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "KyrieIV", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationAgnusXI()
        {
            Keys compositionKey = Keys.e;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.IV, ChangedDegrees = new() { (Degree.III, true) } }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote, WithDot = true } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "AgnusXI", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationAgnusXIII()
        {
            Keys compositionKey = Keys.e;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V }), // sprawdzić
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "AgnusXIII", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        #endregion

        #region grupa3
        public static BaseComposition ModalHarmonizationKyrieIX()
        {
            Keys compositionKey = Keys.e;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "KyrieIX", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationKyrieXIII()
        {
            Keys compositionKey = Keys.e;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.II, ChangedDegrees = new() { (Degree.V, true) } }),
                (new HarmonicFunction() { Function = Degree.II, ChangedDegrees = new() { (Degree.V, true) } }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.II, ChangedDegrees = new() { (Degree.V, true) } }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "KyrieXIII", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationSanctusXIV()
        {
            Keys compositionKey = Keys.e;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VI }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            {
                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote, WithDot = true } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "SanctusXIV", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        public static BaseComposition ModalHarmonizationAgnusII()
        {
            Keys compositionKey = Keys.fis;
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new();

            List<HarmonicFunction> functions = new()
            {
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.IV }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.V }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.III }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.I }),
                (new HarmonicFunction() { Function = Degree.VII }),
                (new HarmonicFunction() { Function = Degree.I }),
            };


            List<List<Pitch>> allPitches = new()
            { 
                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.EigthNote } },
                },

                new()
                {
                    new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } },
                },
            };

            for (int i = 0; i < functions.Count; i++)
                pitchesAndFunctions.Add((new Pitch(allPitches[i], functions[i].GetPitchesInFunction(compositionKey)), functions[i]));

            BaseComposition baseComposition = new() { Name = "AgnusII", VoiceIndex = 0, Key = compositionKey, PitchesAndFunctions = pitchesAndFunctions, Downbeats = new List<double> { 11 } };

            return baseComposition;
        }
        #endregion
    }
}
