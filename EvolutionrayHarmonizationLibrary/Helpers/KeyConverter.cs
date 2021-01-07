using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Helpers
{   
    /// <summary>
    /// Klasa konwertująca tonację na znaki przykluczowe, numer pierwszego stopnia oraz określenie, czy jest molowa.
    /// </summary>
    public static class KeyConverter
    {
        private readonly static (Pitches, Modifiers)[][] keySigns = new (Pitches, Modifiers)[][]
        {
            new (Pitches, Modifiers)[] { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp), (Pitches.E, Modifiers.Sharp), (Pitches.H, Modifiers.Sharp) },
            new (Pitches, Modifiers)[] { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat), (Pitches.G, Modifiers.Flat), (Pitches.C, Modifiers.Flat), (Pitches.F, Modifiers.Flat) },
        };


        public static (List<(Pitches, Modifiers)>, bool isMoll, Pitches firstPitch) KeyToSigns(Keys key)
        {
            (int signsType, int signsCount, bool isMoll, int firstPichNumber) = GetKeyValues(key);
            List<(Pitches, Modifiers)> signs = new List<(Pitches, Modifiers)>();

            for (int i = 0; i < signsCount; i++)
                signs.Add(keySigns[signsType][i]);

            return (signs, isMoll, (Pitches)firstPichNumber);
        }

        private static (int, int, bool, int) GetKeyValues(Keys key)
        {
            int keyNumber = (int)key;
            int singsType = keyNumber / 1000;
            int signsCount = (keyNumber % 1000) / 100;
            bool isMoll = Convert.ToBoolean((keyNumber % 100) / 10);
            int firstPitchNumber = keyNumber % 10;

            return (singsType, signsCount, isMoll, firstPitchNumber);
        }
    }
}
