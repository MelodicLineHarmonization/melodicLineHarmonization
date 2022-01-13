using EvolutionrayHarmonizationLibrary.Algorithm;
using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca funkcję harmoniczną
    /// </summary>
    public class HarmonicFunction
    {
        /// <summary>
        /// Oznaczenie funkcji poprzez wskazanie stopnia, od którego jest budowana
        /// </summary>
        public Degree Function { get; set; }

        /// <summary>
        /// Dźwięk dodany do funkcji, jeśli null, funkcja nie ma dźwięków dodanych.
        /// </summary>
        public Degree? AddedDegree { get; set; }


        /// <summary>
        /// Bazowa funckja zwracająca trójdźwięk zbudowany na stopniu wskazanym przez funkcję.
        /// </summary>
        /// <param name="key">Klucz w jakim będzie rozpatrywana funkcja</param>
        /// <returns></returns>
        public List<PitchInChord> GetPitchesInFunction(Keys key)
        {
            (List<(Pitches, Modifiers)> keySigns, bool isMoll, Pitches firstPitchInKey) = KeyConverter.KeyToSigns(key);
            
            int firstPitchNumber = GetRealNumberOfPitch((int)firstPitchInKey + (int)Function - 1);
            int secondPitchNumber = GetRealNumberOfPitch(firstPitchNumber + 2);
            int thirdPitchNumber = GetRealNumberOfPitch(secondPitchNumber + 2);

            Pitch firstPitch = ApplyKeySigns(firstPitchNumber, keySigns);
            Pitch secondPitch = ApplyKeySigns(secondPitchNumber, keySigns);
            if (isMoll && Function == Degree.V)
                RaiseBySemitone(secondPitch);
            Pitch thirdPitch = ApplyKeySigns(thirdPitchNumber, keySigns);

            if (AddedDegree == null)
                return new List<PitchInChord>
                {
                    new PitchInChord { Pitch = firstPitch, DegreeInChord = Degree.I, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = (Function == Degree.II || Function == Degree.VI) ? 1 : Function == Degree.I ? 3 : 2 },
                    new PitchInChord { Pitch = secondPitch, DegreeInChord = Degree.III, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = (Function == Degree.II || Function == Degree.VI) ? 2 : 1 },
                    new PitchInChord { Pitch = thirdPitch, DegreeInChord = Degree.V, MinimumOccurencesInChord = Function == Degree.I ? 0 : 1, MaximumOccurencesInChord = (Function == Degree.II || Function == Degree.VI) ? 1 : 2 },
                };
            else
            {
                if (AddedDegree.Value == Degree.IX)
                {
                    int fourthPitchNumber = GetRealNumberOfPitch(thirdPitchNumber + 2);
                    int fifthPitchNumber = GetRealNumberOfPitch(fourthPitchNumber + 2);

                    Pitch fourthPitch = ApplyKeySigns(fourthPitchNumber, keySigns);
                    Pitch fifthPitch = ApplyKeySigns(fifthPitchNumber, keySigns);
                    if (!isMoll)
                        LowerBySemitone(fifthPitch);

                    return new List<PitchInChord>
                    {
                        new PitchInChord { Pitch = firstPitch, DegreeInChord = Degree.I, MinimumOccurencesInChord = 0, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = secondPitch, DegreeInChord = Degree.III, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = thirdPitch, DegreeInChord = Degree.V, MinimumOccurencesInChord = 0, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = fourthPitch, DegreeInChord = Degree.VII, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = fifthPitch, DegreeInChord = Degree.IX, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 }
                    };
                }
                else
                {
                    int fourthPitchNumber = GetRealNumberOfPitch((int)firstPitchNumber + (int)AddedDegree.Value - 1);
                    Pitch fourthPitch = ApplyKeySigns(fourthPitchNumber, keySigns);

                    return new List<PitchInChord>
                    {
                        new PitchInChord { Pitch = firstPitch, DegreeInChord = Degree.I, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = secondPitch, DegreeInChord = Degree.III, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = thirdPitch, DegreeInChord = Degree.V, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                        new PitchInChord { Pitch = fourthPitch, DegreeInChord = AddedDegree.Value, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 }
                    };
                }
            }
        }

        public List<Pitch[]> GetAllCorrectInversions(Keys key, PitchLength pitchLength = null)
        {
            List<PitchInChord> pitches = GetPitchesInFunction(key);
            List<Pitch>[] possiblePitchesForVoices = new List<Pitch>[MelodicLine.VoicesRange.Count];

            for (int i = 0; i < possiblePitchesForVoices.Length; i++)
                possiblePitchesForVoices[i] = new();

            foreach (PitchInChord pitch in pitches)
                for (int i = 0; i < possiblePitchesForVoices.Length; i++)
                    possiblePitchesForVoices[i].AddRange(Pitch.GetPossibleOctavesInRange(pitch.Pitch, MelodicLine.VoicesRange[i].Min, MelodicLine.VoicesRange[i].Max));

            List<Pitch[]> inversions = new() { new Pitch[MelodicLine.VoicesRange.Count] };
            for (int i = 0; i < MelodicLine.VoicesRange.Count; i++)
                inversions = AddNextVoice(inversions, possiblePitchesForVoices[i], pitches, i, pitchLength);

            List<Pitch[]> objectsToRemove = new();
            foreach (Pitch[] inversion in inversions)
                if (ConstraintsFunctions.IncorrectPitchesInChord(inversion, pitches) != 0 || ConstraintsFunctions.VoicesCrossover(inversion) != 0)
                    objectsToRemove.Add(inversion);

            inversions.RemoveAll(o => objectsToRemove.Contains(o));

            return inversions;
        }

        private List<Pitch[]> AddNextVoice(List<Pitch[]> buildedChords, List<Pitch> pitchesToAdd, List<PitchInChord> pitchesCount, int voiceIndex, PitchLength pitchLength = null)
        {
            List<Pitch[]> newBuildedChords = new();
            foreach (Pitch[] buildedChord in buildedChords)
                foreach (Pitch pitchToAdd in pitchesToAdd)
                {
                    Pitch[] newChord = buildedChord.Select(p => p?.Copy()).ToArray();
                    Pitch newPitch = pitchToAdd.Copy();
                    newPitch.Length = pitchLength;
                    newChord[voiceIndex] = newPitch;
                    newBuildedChords.Add(newChord);
                }

            List<Pitch[]> objectsToRemove = new();
            foreach (Pitch[] buildedChord in newBuildedChords)
                foreach (PitchInChord pitchCount in pitchesCount)
                {
                    int count = buildedChord.Count(p => p != null && pitchCount.Pitch == p);
                    if (count > pitchCount.MaximumOccurencesInChord)
                    {
                        objectsToRemove.Add(buildedChord);
                        break;
                    }
                }

            newBuildedChords.RemoveAll(o => objectsToRemove.Contains(o));

            return newBuildedChords;
        }

        public HarmonicFunction Copy()
        {
            return new HarmonicFunction
            {
                Function = Function,
                AddedDegree = AddedDegree
            };
        }

        private Pitch ApplyKeySigns(int pitchNumber, List<(Pitches, Modifiers)> keySigns)
        {
            int modifierIndex = keySigns.FindIndex(x => (int)x.Item1 == pitchNumber);
            return new Pitch()
            {
                PitchValue = (Pitches)pitchNumber,
                Octave = 0,
                Modifier = modifierIndex != -1 ? keySigns[modifierIndex].Item2 : Modifiers.None
            };
        }

        private int GetRealNumberOfPitch(int pitchNumber)
        {
            if (pitchNumber > Pitch.maxPitchValue)
                return (pitchNumber % Pitch.pitchesCount);

            return pitchNumber;
        }

        private void RaiseBySemitone(Pitch pitch)
        {
            if (pitch.Modifier == Modifiers.Natural)
                throw new ArgumentOutOfRangeException($"Modifier cannot be Natural when pitch is raised by semitone.");

            pitch.Modifier += 1;

            if ((int)pitch.Modifier > (int)Modifiers.DoubleSharp)
                throw new ArgumentException("Application does not support triple sharp, please change key of composition.");
        }

        private void LowerBySemitone(Pitch pitch)
        {
            if (pitch.Modifier == Modifiers.Natural)
                throw new ArgumentOutOfRangeException($"Modifier cannot be Natural when pitch is lowerd by semitone.");

            if (pitch.Modifier == Modifiers.None)
                pitch.Modifier = Modifiers.Flat;
            else
                pitch.Modifier -= 1;
        
            if ((int)pitch.Modifier < (int)Modifiers.DoubleFlat)
                throw new ArgumentException("Application does not support triple flat, please change key of composition.");
        }
        public static bool operator == (HarmonicFunction left, HarmonicFunction right)
        {
            if (left is null || right is null)
                return false;

            return left.Function == right.Function && left.AddedDegree == right.AddedDegree;
        }

        public static bool operator != (HarmonicFunction left, HarmonicFunction right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            return this == obj as HarmonicFunction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Function, AddedDegree);
        }
    }
}
