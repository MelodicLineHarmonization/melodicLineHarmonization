namespace EvolutionrayHarmonizationLibrary.Helpers.Interfaces
{
    public interface IRandom
    {
        public double NextDouble();
        public int Next(int minValue, int maxValue);
    }
}