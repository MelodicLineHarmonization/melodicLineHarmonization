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
    /// <summary>
    /// Klasa zawierająca funkcje określające ograniczenia (silne i słabe) narzucone na tworzoną kompozycję.
    /// <para> Ograniczenia silne: </para>
    /// <para> 1. Brak krzyżowania głosów. </para>
    /// <para> 2. Tercja dominanty rozwiązana w górę. </para>
    /// <para> 3. Brak kwint i oktaw (przeciw)równoległych. </para>
    /// <para> 4. Brak ruchu wszystkich głosów w jednym kierunku. </para>
    /// <para> 5. Brak skoków o interwały zwiększone. </para>
    /// <para> 6. Poprawne dźwięki w akordzie (poprawne zdwojenie, jeśli potrzebne). </para>
    /// <para> 7. Rozpiętość między głosami max oktawa -> nie dotyczy basu. </para>
    /// <para> Ograniczenia słabe: </para>
    /// <para> 8. Brak semptymy w dwóch krokach (i w jednym). -> tutaj chyba jakiś wyjątek </para>
    /// <para> 9. Brak dwóch następujących akordów na kwincie. </para>
    /// <para> 10. Poprawny dźwięk w basie (brak kwinty w basie na mocnej części taktu). </para>
    /// <para> 11. Poprawne zdwojenie (kwinta w basie, jeśli zdwojona, pryma w basie w pierwszym i ostatnim akordzie). </para>
    /// <para> 12. Ruch przynajmniej 2 głosów. </para>
    /// <para> 13. Wszystkie głosy w dopuszczalnym zakresie. </para>
    /// <para> 14. Płynne prowadzenie głosów (alt, tenor), brak skoku o zbyt duży interwał. </para>
    /// <para> 15. Ruch basu. </para>
    /// <para> 16. Brak zbyt dużych ruchów na przestrzeni dwóch dźwięków (bas). </para>
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
        /// <returns>Wartość boolowska określająca, czy nuta została właściwie rozwiązana, prawda - nuta rozwiązana niepoprawnie lub nuta nie istnieje w akordzie do rozwiązania, prawda - w przeciwnym wypadku.</returns>
        public static bool NoteIncorrectResolution(Pitch[] chord, Pitch[] nextChord, Pitch pitchToResolution, int minSemitoneMove, int maxSemitoneMove)
        {
            int pitchIndex = Array.IndexOf(chord, pitchToResolution);
            if (pitchIndex == -1)
                return true;

            int semitoneDifference = Interval.GetPitchesDifferenceInSemitones(chord[pitchIndex], nextChord[pitchIndex]);
            if (semitoneDifference <= maxSemitoneMove && semitoneDifference >= minSemitoneMove)
                return false;

            return true;
        }

        /// <summary>
        /// 3. Funkcja określająca, czy pomiędzy dwoma kolejnymi akordami znajdują się kwinty lub oktawy równoległe.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns></returns>
        public static int ParallelQuintsAndOctaves(Pitch[] chord, Pitch[] nextChord)
        {
            int quintSum = Interval.GetParallelIntervalsCount(chord, nextChord, Interval.quintSemitones, Interval.quintPitchDistances);
            int octaveSum = Interval.GetParallelIntervalsCount(chord, nextChord, Interval.unisonoOctaveSemitones, Interval.unisonoOctavePitchDistances);
            return quintSum + octaveSum;
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
        /// 5. Funkcja zliczająca ruchy o interwały zwiększone w danej linii melodycznej.
        /// </summary>
        /// <param name="melodicLine"></param>
        /// <returns></returns>
        public static int AugumentedIntervalMoveCount(MelodicLine melodicLine)
        {
            int augumentedCount = 0;
            for (int i = 0; i < melodicLine.Length - 1; i++)
            {
                int semitonesMove = Math.Abs(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));
                int pitchValueDistanve = Pitch.GetPitchValueDistance(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1));

                if (pitchValueDistanve > 2) // at least quart
                {
                    if (pitchValueDistanve * 2 <= semitonesMove)
                        augumentedCount++;
                }
                else // maximum third
                {
                    if (pitchValueDistanve * 2 < semitonesMove)
                        augumentedCount++;
                }

            }

            return augumentedCount;
        }

        /// <summary>
        /// 6. Funkcja sprawdzająca, czy w akordzie występują odpowiednie dźwięki oraz, czy odpowiedni dźwięki jest zdwojony (jeśli konieczne).
        /// </summary>
        /// <param name="chord">Sprawdzany akord</param>
        /// <param name="possiblePitches">Lista możliwych dźwięków w akordzie</param>
        /// <returns>Liczba dźwięków spoza akordu lub o błędnej ilości.</returns>
        public static int IncorrectPitchesInChord(Pitch[] chord, List<PitchInChord> possiblePitches)
        {
            int mistakesCount = 0;
            int[] pitchesCount = new int[possiblePitches.Count];
            foreach (Pitch p in chord)
            {
                int pitchIndex = possiblePitches.FindIndex((piC) => piC.Pitch == p);
                if (pitchIndex != -1)
                    pitchesCount[pitchIndex]++;
            }

            //sum of pitches constraints not fullfilled
            for (int i = 0; i < pitchesCount.Length; i++)
                if (pitchesCount[i] < possiblePitches[i].MinimumOccurencesInChord)
                        mistakesCount += possiblePitches[i].MinimumOccurencesInChord - pitchesCount[i];
                else
                    if (pitchesCount[i] > possiblePitches[i].MaximumOccurencesInChord)
                        mistakesCount += pitchesCount[i] - possiblePitches[i].MaximumOccurencesInChord;

            //pitches not from chord
            int pitchesFromChord = pitchesCount.Sum();
            if (pitchesFromChord < chord.Length)
                mistakesCount += (chord.Length - pitchesFromChord);

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
                if (Math.Abs(Interval.GetPitchesDifferenceInSemitones(chord[i], chord[i + 1])) > Interval.semitonesInOctave)
                    exceedingIntervals++;
            }

            return exceedingIntervals;
        }

        /// <summary>
        /// 8. Funkcja sprawdzająca, czy w jednym (bądź dwóch) ruchach wykonany został skok o septymę.
        /// </summary>
        /// <returns>Zwraca liczbę skoków o septymę w jednym lub dwóch ruchach w całej linii melodycznej.</returns>
        // TODO Istnieje wyjątek (jeden, rzadki) od tej reguły -> sprawdzić i dodać.
        public static int SeptimeMove(MelodicLine melodicLine)
        {
            List<int> moves = new List<int>();
            for (int i = 0; i < melodicLine.Length - 1; i++)
                moves.Add(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));

            int movesCount = moves.Count;
            for (int i = 0; i < movesCount - 1; i++)
                moves.Add(moves[i] + moves[i + 1]);

            return moves.Count(v => Interval.majorMinorSeptimeSemitones.Contains(Math.Abs(v)));
        }

        /// <summary>
        /// 9. Funkcja sprawdzająca, czy dwa następujące po sobie akordy mają kwintę w basie.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="possiblePitches"></param>
        /// <param name="nextChord"></param>
        /// <param name="possibleNextPitches"></param>
        /// <returns></returns>
        public static bool FollowingChordsOnQuint(Pitch[] chord, List<PitchInChord> possiblePitches, Pitch[] nextChord, List<PitchInChord> possibleNextPitches)
        {
            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == Degree.V);
            PitchInChord nextPitch = possibleNextPitches.Find(piC => piC.DegreeInChord == Degree.V);

            if (pitch != null && nextPitch != null && chord[^1] == pitch.Pitch && nextChord[^1] == nextPitch.Pitch)
                return true;

            return false;
        }

        /// <summary>
        /// 10. Funkcja sprawdzająca, czy dany stopień znajduje się w basie.
        /// </summary>
        /// <returns>Wartość boolowska określająca, czy akord ma dany stopień w basie.</returns>
        public static bool DegreeInBass(Pitch[] chord, List<PitchInChord> possiblePitches, Degree degree)
        {
            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == degree);

            return chord[^1] == pitch.Pitch;
        }


        /// <summary>
        /// 11. Funkcja sprawdzająca, czy dany stopień jest zdwojony w akordzie.
        /// </summary>
        /// <returns>Wartość boolowska określająca, czy akord ma zdwojony dany stopień.</returns>
        public static bool? MultipliedDegree(Pitch[] chord, List<PitchInChord> possiblePitches, Degree degree, int count)
        {
            if (possiblePitches.Count > 3)
                return null;

            PitchInChord pitch = possiblePitches.Find(piC => piC.DegreeInChord == degree);
            int degreeCount = chord.Count(p => p == pitch.Pitch);

            return degreeCount >= count;
        }

        /// <summary>
        /// 12. Funkcja sprawdzająca, czy ruszyły się przynajmniej dwa głosy.
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
        /// 13. Funkcja sprawdzająca, czy wszystkie głosy znajdują się w dopuszczalnym zakresie.
        /// </summary>
        /// <param name="chord"></param>
        /// <returns>Liczba głosów znajdujących się poza swoim zakresem.</returns>
        public static int VoicesNotInAppropriateRange(Pitch[] chord)
        {
            int outsideRange = 0;
            for (int i = 0; i < chord.Length; i++)
                if (chord[i] < MelodicLine.VoicesRange[i].Min || chord[i] > MelodicLine.VoicesRange[i].Max)
                    outsideRange++;

            return outsideRange;
        }

        /// <summary>
        /// 14. Funkcja określa płynność prowadzenie linii melodycznej.
        /// </summary>
        /// <returns>Zwracane są dwie wartości: łączna suma odległości półtonowych między kolejnymi dźwiękami 
        /// i liczba skoków przekraczająca maksymalny interwał</returns>
        public static (int, int) GetMelodicLineSmooth(MelodicLine melodicLine, int? maxIntervalSemitones = null)
        {
            int semitonesCount = 0;
            int exceedingIntervals = 0;
            for (int i = 0; i < melodicLine.Length - 1; i++)
            {
                int intervalSemitones = Math.Abs(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));
                semitonesCount += intervalSemitones;
                if (maxIntervalSemitones != null && intervalSemitones > maxIntervalSemitones.Value)
                    exceedingIntervals++;
            }

            return (semitonesCount, exceedingIntervals);
        }

        /// <summary>
        /// 15. Ruch basu.
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="nextChord"></param>
        /// <returns>Boolowska wartość, określająca, czy bas się ruszył</returns>
        public static bool BassMove(Pitch[] chord, Pitch[] nextChord)
        {
            return Interval.GetPitchesDifferenceInSemitones(chord[^1], nextChord[^1]) != 0;
        }
        
        /// <summary>
        /// 16. Funkcja określa czy w dwóch ruchach w danej linii melodycznej został przekroczony zadany interwał.
        /// </summary>
        /// <param name="melodicLine"></param>
        /// <param name="maxMoveInSemitones"></param>
        /// <returns></returns>
        public static int MelodicLineMaxMoveInTwo(MelodicLine melodicLine, int maxMoveInSemitones)
        {
            List<int> moves = new();
            for (int i = 0; i < melodicLine.Length - 1; i++)
                moves.Add(Interval.GetPitchesDifferenceInSemitones(melodicLine.GetPitch(i), melodicLine.GetPitch(i + 1)));

            int bigerThenMaxMove = 0;
            for (int i = 0; i < moves.Count - 1; i++)
                if (Math.Abs(moves[i]) + Math.Abs(moves[i + 1]) > maxMoveInSemitones)
                    bigerThenMaxMove++;

            return bigerThenMaxMove;
        }
    }
}
