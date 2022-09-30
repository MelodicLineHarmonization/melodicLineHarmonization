using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryHarmonization
{
    public static class TonalHarmonizationExamples
    {
        public static BaseComposition CreateEasyD_S73Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyD_S73", VoiceIndex = 0, Key = Keys.D, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyC_S46Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyC_S46", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasya_S47Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easya_S47", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyC_S49Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyC_S49", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasya_S51Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),

                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easya_S51", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyd_S107Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "Easyd_S107", VoiceIndex = 0, Key = Keys.d, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyF_S108Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),

                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyF_S108", VoiceIndex = 0, Key = Keys.F, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateAllDegreesC_S267()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesC_S267", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }


        public static BaseComposition CreateAllDegreesc_S267()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.Flat, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreescm_S267", VoiceIndex = 0, Key = Keys.c, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

        public static BaseComposition CreateAllDegreesC_S276()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesC_S276", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateAllDegreesc_S282()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Natural, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "AllDegreesc_S282", VoiceIndex = 0, Key = Keys.c, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.HalfNote, Numerator = 2 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }


        public static BaseComposition CreateEasyWithAddedC_S46Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedC_S46Example", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyWithAddeda_S47Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddeda_S47", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }


        public static BaseComposition CreateEasyWithAddedD_S73Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedD_S73", VoiceIndex = 0, Key = Keys.D, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyWithAddedC_S49Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.II }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I }),
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedC_S49", VoiceIndex = 0, Key = Keys.C, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyWithAddeda_S51Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.VI }),

                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.Sharp, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddeda_S51", VoiceIndex = 0, Key = Keys.a, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyWithAddedd_S107Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.Sharp, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.E, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.WholeNote } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedd_S107", VoiceIndex = 0, Key = Keys.d, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 4 }, Downbeats = new List<double> { 1, 3 } };

            return baseComposition;
        }

        public static BaseComposition CreateEasyWithAddedF_S108Example()
        {
            List<(Pitch, HarmonicFunction)> pitchesAndFunctions = new()
            {
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.A, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV, AddedDegree = Degree.VI }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),

                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.VI }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.I }),
                (new Pitch { PitchValue = Pitches.D, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.H, Modifier = Modifiers.Flat, Octave = 5, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.IV }),
                (new Pitch { PitchValue = Pitches.G, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.VII }),
                (new Pitch { PitchValue = Pitches.C, Modifier = Modifiers.None, Octave = 6, Length = new PitchLength { LengthValue = Values.QuarterNote } }, new HarmonicFunction { Function = Degree.V, AddedDegree = Degree.IX }),
                (new Pitch { PitchValue = Pitches.F, Modifier = Modifiers.None, Octave = 5, Length = new PitchLength { LengthValue = Values.HalfNote, WithDot = true } }, new HarmonicFunction { Function = Degree.I })
            };

            BaseComposition baseComposition = new() { Name = "EasyWithAddedF_S108", VoiceIndex = 0, Key = Keys.F, PitchesAndFunctions = pitchesAndFunctions, TimeSignature = new TimeSignature { Denominator = Values.QuarterNote, Numerator = 3 }, Downbeats = new List<double> { 1 } };

            return baseComposition;
        }

    }
}
