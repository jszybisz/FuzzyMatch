# Fuzzy Match

Library is used to perform **fuzzy matching** (matching **simillar** strings ). It uses Levenshtein Distance algorithms to perform this operation. User can specify sensitive of algorithm using *maxDistance* parameter. 

#### Levenshtein Distance
In information theory, linguistics and computer science, the Levenshtein distance is a string metric for measuring the difference between two sequences. Informally, the Levenshtein distance between two words is the minimum number of single-character edits (insertions, deletions or substitutions) required to change one word into the other. It is named after the Soviet mathematician Vladimir Levenshtein, who considered this distance in 1965.[1]
https://en.wikipedia.org/wiki/Levenshtein_distance

#### Usage
```
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


```