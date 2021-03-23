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
            if (isMoll)
                RaiseBySemitone(secondPitch);
            Pitch thirdPitch = ApplyKeySigns(thirdPitchNumber, keySigns);

            return new List<PitchInChord>
            {
                new PitchInChord { Pitch = firstPitch, DegreeInChord = Degree.I, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 2 },
                new PitchInChord { Pitch = secondPitch, DegreeInChord = Degree.III, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 1 },
                new PitchInChord { Pitch = thirdPitch, DegreeInChord = Degree.V, MinimumOccurencesInChord = 1, MaximumOccurencesInChord = 2 },
            };
        }

        public HarmonicFunction Copy()
        {
            return new HarmonicFunction
            {
                Function = Function
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

            //TODO błędny porównanie, do poprawy
            if ((int)pitch.Modifier > Pitch.maxPitchValue)
                throw new ArgumentException("Application does not support triple sharp, please change key of composition.");
        }
    }
}
