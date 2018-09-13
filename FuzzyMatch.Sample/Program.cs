using System;
using JacekSzybisz.FuzzyMatch;
using JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance;

namespace FuzzyMatch.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            IFuzzyMatchProvider fuzzyMatchProvider = new FuzzyMatchProvider(new LevenshteinDistanceService());

       
            var isMatch = fuzzyMatchProvider.IsMatch("Honda", "Hyundai", 2);
            if (isMatch)
            {
                Console.WriteLine("Honda and Hyundai is similar enough to be considered as match");
            }
        }
    }
}
