using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using System.Collections.Generic;
using Xunit;

namespace EvolutionaryHarmonizationLibraryTest
{
    public class ConstraintFunctionsTests
    {
        [Fact]
        public void CrossedVoicesReturnsTwo()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            int crossedVoices = ConstraintsFunctions.VoicesCrossover(firstChord);
            Assert.Equal(2, crossedVoices);
        }

        [Fact]
        public void CrossedVoicesReturnsZero()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };

            int crossedVoices = ConstraintsFunctions.VoicesCrossover(firstChord);
            Assert.Equal(0, crossedVoices);
        }

        [Fact]
        public void NoteCorrectResolutionReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };
            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };

            Pitch noteToResolution = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.A };
            int minSemitones = -1;
            int maxSemitones = -1;
            bool resolution = ConstraintsFunctions.NoteCorrectResolution(firstChord, secondChord, noteToResolution, minSemitones, maxSemitones);
            Assert.True(resolution);

        }

        [Fact]
        public void NoteCorrectResolutionReturnsFalse()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };
            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 2, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.E }
            };

            Pitch noteToResolution = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.A };
            int minSemitones = -1;
            int maxSemitones = -1;
            bool resolution = ConstraintsFunctions.NoteCorrectResolution(firstChord, secondChord, noteToResolution, minSemitones, maxSemitones);
            Assert.False(resolution);
        }

        [Fact]
        public void ParellelQuintsReturnsTwo()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 1, PitchValue = Pitches.F },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.F }
            };

            int quintsCount = ConstraintsFunctions.ParallelQuintsAndOctaves(firstChord, secondChord);
            Assert.Equal(2, quintsCount);
        }


        [Fact]
        public void ParellelOctavesReturnsTwo()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.E }
            };

            int quintsCount = ConstraintsFunctions.ParallelQuintsAndOctaves(firstChord, secondChord);
            Assert.Equal(2, quintsCount);
        }

        [Fact]
        public void AllVoicesOneDirectionVoicesUpReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 4, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 3, PitchValue = Pitches.F }
            };

            bool oneDirection = ConstraintsFunctions.AllVoicesOneDirection(firstChord, secondChord);
            Assert.True(oneDirection);
        }

        [Fact]
        public void AllVoicesOneDirectionVoicesDownReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 0, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.F }
            };

            bool oneDirection = ConstraintsFunctions.AllVoicesOneDirection(firstChord, secondChord);
            Assert.True(oneDirection);
        }

        [Fact]
        public void AllVoicesOneDirectionVoicesStillReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            bool oneDirection = ConstraintsFunctions.AllVoicesOneDirection(firstChord, secondChord);
            Assert.True(oneDirection);
        }

        [Fact]
        public void AllVoicesOneDirectionReturnsFalse()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.A }
            };

            bool oneDirection = ConstraintsFunctions.AllVoicesOneDirection(firstChord, secondChord);
            Assert.False(oneDirection);
        }

        [Fact]
        public void AugumentedIntervalMoveCountReturnsTwo()
        {
            List<Pitch> pitches = new List<Pitch>
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 2, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.Sharp, Octave = 2, PitchValue = Pitches.E },
            };
            MelodicLine melodicLine = new MelodicLine(pitches, false);

            int augumentedMove = ConstraintsFunctions.AugumentedIntervalMoveCount(melodicLine);
            Assert.Equal(2, augumentedMove);
        }

        [Fact]
        public void IncorrectPitchesInChordReturnsTwo()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };
            List<PitchInChord> possiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.E }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 1, MinimumOccurencesInChord = 1},
            };

            int incorrectPitches = ConstraintsFunctions.IncorrectPitchesInChord(firstChord, possiblePitches);
            Assert.Equal(3, incorrectPitches);
        }

        [Fact]
        public void IncorrectPitchesInChordReturnsZero()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E }
            };
            List<PitchInChord> possiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.E }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            int incorrectPitches = ConstraintsFunctions.IncorrectPitchesInChord(firstChord, possiblePitches);
            Assert.Equal(0, incorrectPitches);
        }

        [Fact]
        public void WiderThanOctaveReturnsOne()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C }
            };

            int widerThanOctave = ConstraintsFunctions.WiderThanOctaveSpread(firstChord);
            Assert.Equal(1, widerThanOctave);
        }

        [Fact]
        public void WiderThanOctaveReturnsZero()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }
            };

            int widerThanOctave = ConstraintsFunctions.WiderThanOctaveSpread(firstChord);
            Assert.Equal(0, widerThanOctave);
        }

        [Fact]
        public void SeptimMoveCountReturnsTwo()
        {
            List<Pitch> pitches = new List<Pitch>
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 1, PitchValue = Pitches.H },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.None, Octave = 3, PitchValue = Pitches.E },
            };
            MelodicLine melodicLine = new MelodicLine(pitches, false);

            int septimMoveCount = ConstraintsFunctions.SeptimeMove(melodicLine);
            Assert.Equal(2, septimMoveCount);
        }

        [Fact]
        public void FollowingChordsOnQuintReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };
            List<PitchInChord> firstPossiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.G }, DegreeInChord = Degree.V, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.F },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.F },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C }
            };
            List<PitchInChord> secondPossiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.F }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.V, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            bool followingOnQuints = ConstraintsFunctions.FollowingChordsOnQuint(firstChord, firstPossiblePitches, secondChord, secondPossiblePitches);
            Assert.True(followingOnQuints);
        }

        [Fact]
        public void FollowingChordsOnQuintReturnsFalse()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };
            List<PitchInChord> firstPossiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.G }, DegreeInChord = Degree.V, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.F },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.F }
            };
            List<PitchInChord> secondPossiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.F }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.V, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            bool followingOnQuints = ConstraintsFunctions.FollowingChordsOnQuint(firstChord, firstPossiblePitches, secondChord, secondPossiblePitches);
            Assert.False(followingOnQuints);
        }

        [Fact]
        public void DoubleDegreeInBassReturnsTrue()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C }
            };
            List<PitchInChord> possiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.E }, DegreeInChord = Degree.III, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            bool? doubledInBass = ConstraintsFunctions.DoubledDegreeInBass(firstChord, possiblePitches, Degree.I);
            Assert.True(doubledInBass);
        }

        [Fact]
        public void DoubleDegreeInBassReturnsFalse()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };
            List<PitchInChord> possiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.E }, DegreeInChord = Degree.III, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            bool? doubledInBass = ConstraintsFunctions.DoubledDegreeInBass(firstChord, possiblePitches, Degree.I);
            Assert.False(doubledInBass);
        }

        [Fact]
        public void DoubleDegreeInBassReturnsNull()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G }
            };
            List<PitchInChord> possiblePitches = new List<PitchInChord>
            {
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.C }, DegreeInChord = Degree.I, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
                new PitchInChord { Pitch = new Pitch { Modifier = Modifiers.None, Octave = 0, PitchValue = Pitches.E }, DegreeInChord = Degree.III, MaximumOccurencesInChord = 2, MinimumOccurencesInChord = 1},
            };

            bool? doubledInBass = ConstraintsFunctions.DoubledDegreeInBass(firstChord, possiblePitches, Degree.I);
            Assert.Null(doubledInBass);
        }

        [Fact]
        public void AtLeastTwoVoicesMoveReturnsOne()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            int moreThanTwo = ConstraintsFunctions.AtLeastTwoVoicesMove(firstChord, secondChord);
            Assert.Equal(1, moreThanTwo);
        }

        [Fact]
        public void AtLeastTwoVoicesMoveReturnsZero()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.D },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.G }
            };

            Pitch[] secondChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.A },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H }
            };

            int moreThanTwo = ConstraintsFunctions.AtLeastTwoVoicesMove(firstChord, secondChord);
            Assert.Equal(0, moreThanTwo);
        }

        [Fact]
        public void VoicesNotInAppropriateRangeReturnsOne()
        {
            Pitch[] firstChord = new Pitch[4]
            {
                new Pitch { Modifier = Modifiers.None, Octave = 5, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 6, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 5, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.G }
            };

            int notInRange = ConstraintsFunctions.VoicesNotInAppropriateRange(firstChord);
            Assert.Equal(1, notInRange);
        }

        [Fact]
        public void GetMelodicLineSmoothReturnsHEHEOneIntervalWiderThanMax()
        {
            List<Pitch> pitches = new List<Pitch>
            {
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.G },
                new Pitch { Modifier = Modifiers.None, Octave = 1, PitchValue = Pitches.E },
                new Pitch { Modifier = Modifiers.None, Octave = 2, PitchValue = Pitches.C },
                new Pitch { Modifier = Modifiers.Flat, Octave = 2, PitchValue = Pitches.H },
            };
            MelodicLine melodicLine = new MelodicLine(pitches, false);

            (int semitones, int widerCount) = ConstraintsFunctions.GetMelodicLineSmooth(melodicLine, Interval.majorMinorSeptimeSemitones[^1] - 1);
            Assert.Equal(1, widerCount);
            Assert.Equal(28, semitones);
        }
    }
}
