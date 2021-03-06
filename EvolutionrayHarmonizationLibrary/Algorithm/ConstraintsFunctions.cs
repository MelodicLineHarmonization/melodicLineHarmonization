using EvolutionrayHarmonizationLibrary.Enums;
using EvolutionrayHarmonizationLibrary.Helpers;
using EvolutionrayHarmonizationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Algorithm
{
    //TODO 5, 8, 9, 10.
    /// <summary>
    /// Klasa zawierająca funkcje określające ograniczenia (silne i słabe) narzucone na tworzoną kompozycję.
    /// Ograniczenia silne:
    /// 1. Brak krzyżowania głosów.
    /// 2. Tercja dominanty rozwiązana w górę. 
    /// 3. Brak kwint równoległych.
    /// 4. Brak ruchu wszystkich głosów w jednym kierunku.
    /// 5. Brak skoków o interwały zwiększone.
    /// 6. Poprawne dźwięki w akordzie (poprawne zdwojenie, jeśli potrzebne).
    /// 7. Rozpiętość między głosami max oktawa -> nie dotyczy basu.
    /// Ograniczenia słabe:
    /// 8. Brak semptymy w dwóch krokach (i w jednym).
    /// 9. Brak dwóch następujących akordów na kwincie.
    /// 10. Zdwojenie kwinty w basie.
    /// 11. Ruch przynajmniej 2 głosów.
    /// 12. Wszystkie głosy w dopuszczalnym zakresie.
    /// 13. Płynne prowadzenie głosów (alt, tenor), brak skoku o zbyt duży interwał.
    /// </summary>
    public static class ConstraintsFunctions
    {
        /// <summary>
        /// 1. Funkcja określająca, czy w danym akordzie krzyżują się dwa sąsiadujące głosy.
        /// </summary>
        /// <param name="chord"></param>
        /// <returns></returns>
        public static int VoicesCrossover(Pitch[] chord)
        {
            int crossedVoices = 0;
            for (int i = 0; i < chord.Length - 1; i++)
            {
                int differenceInSemitones = Interval.GetPitchesDifferenceInSemitones(chord[i], chord[i + 1]);

                if (differenceInSemitones < 0)
                    crossedVoices++;
            }

            return crossedVoices;
        }

        /// <summary>
        /// 2. Funkcja sprawdzająca, czy dany dźwięk z pierwszego akordu rozwiązuje się we właściwy sposób.
        /// </summary>
        /// <param name="chord">Akord poprzedzający</param>
        /// <param name="nextChord">Akord następujący</param>
        /// <param name="pitchToResolution">Dźwięk, z żądanym sposobem rozwiązania</param>
        /// <param name="minSemitoneMove">Minimalna wartość w półtonach żądanego przesunięcia (wartość ujemna -> rozwiązanie w dół)</param>
        /// <param name="maxSemitoneMove">Maksymalna wartość w półtonach żądnaego przesunięcia (wartość ujemna -> rozwiązanie w dół)</param>
        /// <returns>Wartość boolowska określająca, czy nuta została właściwie rozwiązana</returns>
        public static bool NoteCorrectResolution(Pitch[] chord, Pitch[] nextChord, Pitch pitchToResolution, int minSemitoneMove, int maxSemitoneMove)
        {
            int pitchIndex = Array.IndexOf(chord, pitchToResolution);
            if (pitchIndex == -1)
                throw new ArgumentException("Pitch to resolution not found in first chord.");

            int semitoneDifference = Interval.GetPitchesDifferenceInSemitones(chord[pitchIndex], nextChord[pitchIndex]);
            if (semitoneDifference <= maxSemitoneMove && semitoneDifference >= minSemitoneMove)
                return true;

            return false;
        }

        /// <summary>
        /// 3. Funkcja określająca, czy pomiędzy dwoma kolejnymi akordami znajdują się kwinty równoległe.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static int ParallelQuints(Pitch[] chord, Pitch[] nextChord)
        {
            return Interval.GetParallelIntervalsCount(chord, nextChord, Interval.quintSemitones, Interval.quintPitchDistances);
        }

        /// <summary>
        /// 4. Funkcja określająca, czy wszystkie głosy poruszły się w tym samym kierunku, lub czy żaden głos się nie poruszył.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns>Prawda, jeśli wszystkie głosy ruszyły się w tym samym kierunku lub nie ruszył się żaden.</returns>
        public static bool AllVoicesOneDirection(Pitch[] chord, Pitch[] nextChord)
        {
            int[] directions = new int[chord.Length];
            for (int i = 0; i < chord.Length; i++)
                directions[i] = Math.Sign(Interval.GetPitchesDifferenceInSemitones(chord[i], nextChord[i]));

            int directionsSum = directions.Sum();
            if (Math.Abs(directionsSum) == chord.Length)
                return true;

            if (directionsSum == 0 && directions.All(v => v == 0))
                return true;

            return false;
        }

        /// <summary>
        /// 6. Funkcja sprawdzająca, czy w akordzie występują odpowiednie dźwięki oraz, czy odpowiedni dźwięki jest zdwojony (jeśli konieczne).
        /// </summary>
        /// <param name="chord">Sprawdzany akord</param>
        /// <param name="possiblePitches">Lista możliwych dźwięków w akordzie</param>
        /// <returns>Liczba dźwięków spoza akordu lub o błędnej ilości.</returns>
        public static int CorrectPitchesInChord(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            int mistakesCount = 0;
            int[] pitchesCount = new int[possiblePitches.Count];
            foreach (Pitch p in chord)
            {
                int pitchIndex = possiblePitches.FindIndex((piC) => piC.Pitch == p);
                if (pitchIndex != -1)
                    pitchesCount[pitchIndex]++;
            }

            for (int i = 0; i < pitchesCount.Length; i++)
                if (pitchesCount[i] < possiblePitches[i].MinimumOccurencesInChord)
                        mistakesCount += possiblePitches[i].MinimumOccurencesInChord - pitchesCount[i];
                else
                    if (pitchesCount[i] > possiblePitches[i].MaximumOccurencesInChord)
                        mistakesCount += pitchesCount[i] - possiblePitches[i].MaximumOccurencesInChord;
            
            return mistakesCount;
        }

        /// <summary>
        /// 7. Funkcja sprawdzająca, czy w jednym akordzie dwa głosy znajdują się w większej odległości niż oktawa (nie dotyczy basu).
        /// </summary>
        /// <param name="chord"></param>
        /// <returns>Ilość interwałów przekraczających oktawę.</returns>
        public static int WiderThanOctaveSpread(Pitch[] chord)
        {
            int exceedingIntervals = 0;
            // Excluding last note
            for (int i = 0; i < chord.Length - 2; i++)
            {
                if (Interval.GetPitchesDifferenceInSemitones(chord[i], chord[i + 1]) >= Interval.semitonesInOctave)
                    exceedingIntervals++;
            }

            return exceedingIntervals;
        }

        /// <summary>
        /// 11. Funkcja sprawdzająca, czy ruszyły się przynajmniej dwa głosy.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns>Liczba głosów powyżej dwóch, które się nie ruszyły.</returns>
        public static int AtLeastTwoVoicesMove(Pitch[] chord, Pitch[] nextChord)
        {
            int[] directions = new int[chord.Length];
            for (int i = 0; i < chord.Length; i++)
                directions[i] = Math.Sign(Interval.GetPitchesDifferenceInSemitones(chord[i], nextChord[i]));

            int noMoveVoicesCount = directions.Count(v => v == 0);

            if (noMoveVoicesCount > 2)
                return noMoveVoicesCount - 2;

            return 0;
        }

        /// <summary>
        /// 12. Funkcja sprawdzająca, czy wszystkie głosy znajdują się w dopuszczalnym zakresie.
        /// </summary>
        /// <param name="chord"></param>
        /// <returns>Liczba głosów znajdujących się poza swoim zakresem.</returns>
        public static int VoicesInAppropriateRange(Pitch[] chord)
        {
            int outsideRange = 0;
            for (int i = 0; i < chord.Length; i++)
                if (chord[i] < MelodicLine.VoicesRange[i].Min || chord[i] > MelodicLine.VoicesRange[i].Max)
                    outsideRange++;

            return outsideRange;
        }

        /// <summary>
        /// 13. Funkcja określa płynność prowadzenie linii melodycznej.
        /// </summary>
        /// <returns>Zwracane są dwie wartości: łączna suma odległości półtonowych między kolejnymi dźwiękami 
        /// i liczba skoków przekraczająca maksymalny interwał</returns>
        // TODO Sprawdzić czy działa :)
        public static (int, int) GetMelodicLineSmooth(MelodicLine melodicLine, int maxIntervalSemitones)
        {
            int semitonesCount = 0;
            int exceedingIntervals = 0;
            for (int i = 0; i < melodicLine.Length - 1; i++)
            {
                int intervalSemitones = Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1));
                semitonesCount += intervalSemitones;
                if (intervalSemitones > maxIntervalSemitones)
                    exceedingIntervals++;
            }

            return (semitonesCount, exceedingIntervals);
        }
    }
}
