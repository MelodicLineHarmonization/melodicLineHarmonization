using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using Xunit;

namespace EvolutionaryHarmonizationLibraryTest
{
    public class QualityFunctionsTest
    {
        [Fact]
        public void ParellelSixthsReturnsTwo()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };

            int sixthsCount = QualityFunctions.ParallelSixths(firstChord, secondChord);
            Assert.Equal(2, sixthsCount);
        }

        [Fact]
        public void ContrarySporanoBassMoveReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };

            bool contraryMove = QualityFunctions.ContraryBassSopranoMove(firstChord, secondChord);
            Assert.True(contraryMove);
        }

        [Fact]
        public void ContrarySporanoBassMoveReturnsFalse()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.E }
            };

            bool contraryMove = QualityFunctions.ContraryBassSopranoMove(firstChord, secondChord);
            Assert.False(contraryMove);
        }

        [Fact]
        public void ContraryMoveOnQuintReturnsOne()
        {
            Pitch[] firstChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A }
            };

            Pitch[] secondChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };

            int contraryCount = QualityFunctions.ContraryMoveOnPerfectInterval(firstChord, secondChord);
            Assert.Equal(1, contraryCount);
        }

        [Fact]
        public void ContraryMoveOnQuintReturnsZero()
        {
            Pitch[] firstChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A }
            };

            Pitch[] secondChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };

            int contraryCount = QualityFunctions.ContraryMoveOnPerfectInterval(firstChord, secondChord);
            Assert.Equal(0, contraryCount);
        }

        [Fact]
        public void ContraryMoveOnOctaveReturnsOne()
        {
            Pitch[] firstChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A }
            };

            Pitch[] secondChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C }
            };

            int contraryCount = QualityFunctions.ContraryMoveOnPerfectInterval(firstChord, secondChord);
            Assert.Equal(1, contraryCount);
        }

        [Fact]
        public void ContraryMoveOnOctaveReturnsZero()
        {
            Pitch[] firstChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.F }
            };

            Pitch[] secondChord = new Pitch[2]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C }
            };

            int contraryCount = QualityFunctions.ContraryMoveOnPerfectInterval(firstChord, secondChord);
            Assert.Equal(0, contraryCount);
        }

        [Fact]
        public void ChordBreadthReturns5()
        {
            Pitch[] firstChord = new Pitch[3]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.F }
            };

            int chordBreadth = QualityFunctions.ChordBreadth(firstChord);
            Assert.Equal(5, chordBreadth);
        }
    }
}
