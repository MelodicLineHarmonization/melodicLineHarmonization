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
        public HarmonicFunctions Function { get; set; }


        /// <summary>
        /// Bazowa funckja zwracająca trójdźwięk zbudowany na stopniu wskazanym przez funkcję.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Pitch> GetPitchesInFunction(Keys key)
        {
            (List<(Pitches, Modifiers)> keySigns, bool isMoll, Pitches firstPitchInKey) = KeyConverter.KeyToSigns(key);
            
            int firstPitchNumber = GetRealNumberOfPitch((int)firstPitchInKey + (int)Function - 1);
            int secondPitchNumber = GetRealNumberOfPitch(firstPitchNumber + 2);
            int thirdPitchNumber = GetRealNumberOfPitch(secondPitchNumber + 2);

            Pitch firstPitch = ApplyKeySigns(firstPitchNumber, keySigns);
            Pitch secondPitch = ApplyKeySigns(secondPitchNumber, keySigns);
            if (isMoll)
                RaiseBySemitone(secondPitch);
            Pitch thridPitch = ApplyKeySigns(thirdPitchNumber, keySigns);

            return new List<Pitch>() { firstPitch, secondPitch, thridPitch };
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
                Octave = null,
                Modifier = modifierIndex != -1 ? keySigns[modifierIndex].Item2 : Modifiers.None
            };
        }

        private int GetRealNumberOfPitch(int pitchNumber)
        {
            if (pitchNumber > Pitch.maxPitchValue)
                return (pitchNumber % Pitch.pitchesCount) + Pitch.minPitchValue;

            return pitchNumber;
        }

        private void RaiseBySemitone(Pitch pitch)
        {
            if (pitch.Modifier == Modifiers.Natural)
                throw new ArgumentOutOfRangeException($"Modifier cannot be Natural when pitch is raised by semitone.");

            pitch.Modifier += 1;

            if ((int)pitch.Modifier > Pitch.maxPitchValue)
                throw new ArgumentException("Application does not support triple sharp, please change key of composition.");
        }
    }
}
