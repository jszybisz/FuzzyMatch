using System;
using System.Globalization;

namespace JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance
{
    /// <summary>
    /// Class LevenshteinDistance.
    /// </summary>
    public class LevenshteinDistanceService : ILevenshteinDistanceService
    {
        /// <summary>
        /// Gets the levenshtein distance with limit.
        /// </summary>
        /// <param name="pattern">The first string.</param>
        /// <param name="stringToMatch">The second string.</param>
        /// <param name="maxDistance">The maximum distance.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>System.Int32.</returns>
        public  Distance GetLevenshteinDistance(string pattern, string stringToMatch, int? maxDistance =null, bool ignoreCase =false)
        {
            if (maxDistance == null)
            {
                maxDistance = Int32.MaxValue;
            }

            var firstPhrase = (ignoreCase ? pattern?.ToLower(CultureInfo.CurrentCulture) : pattern) ?? string.Empty;
            var secondPhrase = (ignoreCase ? stringToMatch?.ToLower(CultureInfo.CurrentCulture) : stringToMatch) ?? string.Empty;


            if (firstPhrase == secondPhrase)
            {
                return Distance.Ok(0);
            }

            var minDistance = Math.Abs(firstPhrase.Length - secondPhrase.Length);
            if (maxDistance < minDistance)
            {
                return Distance.OutOfRange();
            }

            var d = new int[firstPhrase.Length + 1, secondPhrase.Length + 1];

            for (var i = 0; i <= firstPhrase.Length; i++)
            {
                d[i, 0] = i;
            }
            for (var j = 0; j <= secondPhrase.Length; j++)
            {
                d[0, j] = j;
            }

            for (var j = 1; j <= secondPhrase.Length; j++)
            {
                var lowestPossibleDistance = maxDistance + 1;
                for (var i = 1; i <= firstPhrase.Length; i++)
                {
                    int min;
                    if (firstPhrase[i - 1] == secondPhrase[j - 1])
                    {
                        min = d[i - 1, j - 1];
                    }
                    else
                    {
                        min = Math.Min(Math.Min(
                                d[i - 1, j] + 1, // a deletion
                                d[i, j - 1] + 1), //an Insertion
                            d[i - 1, j - 1] + 1); // a substitution
                    }
                    d[i, j] = min;
                    if (lowestPossibleDistance > min)
                    {
                        lowestPossibleDistance = min;
                    }
                }
                if (lowestPossibleDistance > maxDistance)
                {
                    return Distance.OutOfRange();
                }
            }

            return Distance.Ok(d[firstPhrase.Length, secondPhrase.Length]);
        }

       
    }
}