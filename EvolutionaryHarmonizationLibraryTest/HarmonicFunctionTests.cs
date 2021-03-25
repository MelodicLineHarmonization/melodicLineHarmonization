using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolutionaryHarmonizationLibraryTest
{
    public class HarmonicFunctionTests
    {
        [Fact]
        public void GetPitchesInFunctionKeyGDegreeIReturnsCorrectPitches()
        {
            HarmonicFunction harmonicFunction = new() { Function = Degree.I };
            List<PitchInChord> pitches = harmonicFunction.GetPitchesInFunction(Keys.G);

            Assert.Equal(3, pitches.Count);
            Assert.Equal(Degree.I, pitches[0].DegreeInChord);
            Assert.Equal(2, pitches[0].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[0].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[0].Pitch.Modifier);
            Assert.Equal(Pitches.G, pitches[0].Pitch.PitchValue);
            Assert.Equal(0, pitches[0].Pitch.Octave);

            Assert.Equal(Degree.III, pitches[1].DegreeInChord);
            Assert.Equal(1, pitches[1].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[1].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[1].Pitch.Modifier);
            Assert.Equal(Pitches.H, pitches[1].Pitch.PitchValue);
            Assert.Equal(0, pitches[1].Pitch.Octave);

            Assert.Equal(Degree.V, pitches[2].DegreeInChord);
            Assert.Equal(2, pitches[2].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[2].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[2].Pitch.Modifier);
            Assert.Equal(Pitches.D, pitches[2].Pitch.PitchValue);
            Assert.Equal(0, pitches[2].Pitch.Octave);
        }


        [Fact]
        public void GetPitchesInFunctionKeyGDegreeIVReturnsCorrectPitches()
        {
            HarmonicFunction harmonicFunction = new() { Function = Degree.IV };
            List<PitchInChord> pitches = harmonicFunction.GetPitchesInFunction(Keys.G);

            Assert.Equal(3, pitches.Count);
            Assert.Equal(Degree.I, pitches[0].DegreeInChord);
            Assert.Equal(2, pitches[0].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[0].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[0].Pitch.Modifier);
            Assert.Equal(Pitches.C, pitches[0].Pitch.PitchValue);
            Assert.Equal(0, pitches[0].Pitch.Octave);

            Assert.Equal(Degree.III, pitches[1].DegreeInChord);
            Assert.Equal(1, pitches[1].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[1].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[1].Pitch.Modifier);
            Assert.Equal(Pitches.E, pitches[1].Pitch.PitchValue);
            Assert.Equal(0, pitches[1].Pitch.Octave);

            Assert.Equal(Degree.V, pitches[2].DegreeInChord);
            Assert.Equal(2, pitches[2].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[2].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[2].Pitch.Modifier);
            Assert.Equal(Pitches.G, pitches[2].Pitch.PitchValue);
            Assert.Equal(0, pitches[2].Pitch.Octave);
        }

        [Fact]
        public void GetPitchesInFunctionKeyGDegreeVReturnsCorrectPitches()
        {
            HarmonicFunction harmonicFunction = new() { Function = Degree.V };
            List<PitchInChord> pitches = harmonicFunction.GetPitchesInFunction(Keys.G);

            Assert.Equal(3, pitches.Count);
            Assert.Equal(Degree.I, pitches[0].DegreeInChord);
            Assert.Equal(2, pitches[0].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[0].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[0].Pitch.Modifier);
            Assert.Equal(Pitches.D, pitches[0].Pitch.PitchValue);
            Assert.Equal(0, pitches[0].Pitch.Octave);

            Assert.Equal(Degree.III, pitches[1].DegreeInChord);
            Assert.Equal(1, pitches[1].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[1].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.Sharp, pitches[1].Pitch.Modifier);
            Assert.Equal(Pitches.F, pitches[1].Pitch.PitchValue);
            Assert.Equal(0, pitches[1].Pitch.Octave);

            Assert.Equal(Degree.V, pitches[2].DegreeInChord);
            Assert.Equal(2, pitches[2].MaximumOccurencesInChord);
            Assert.Equal(1, pitches[2].MinimumOccurencesInChord);
            Assert.Equal(Modifiers.None, pitches[2].Pitch.Modifier);
            Assert.Equal(Pitches.A, pitches[2].Pitch.PitchValue);
            Assert.Equal(0, pitches[2].Pitch.Octave);
        }

        [Fact]
        public void GetAllInversionsKeyCDegreeIReturns136()
        {
            HarmonicFunction harmonicFunction = new() { Function = Degree.I };
            List<Pitch[]> inversions = harmonicFunction.GetAllCorrectInversions(Keys.C);
            Assert.Equal(136, inversions.Count);
        }
    }
}
