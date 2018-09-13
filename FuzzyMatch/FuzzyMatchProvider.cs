using JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance;

namespace JacekSzybisz.FuzzyMatch
{
    /// <summary>
    /// Class FuzzyMatchProvider.
    /// </summary>
    /// <seealso cref="IFuzzyMatchProvider" />
    public class FuzzyMatchProvider : IFuzzyMatchProvider
    {
        private readonly ILevenshteinDistanceService _levenshteinDistanceService;

        public FuzzyMatchProvider(ILevenshteinDistanceService levenshteinDistanceService)
        {
            _levenshteinDistanceService = levenshteinDistanceService;
        }
        /// <summary>
        /// Checks if there is fuzzy match between strings. Sum of DoubleMetaphone and Levenshatein distance to evaluate value
        /// </summary>
        /// <param name="pattern">Pattern to match</param>
        /// <param name="stringToMatch">string that shoudl match pattern</param>
        /// <param name="maxLevenshteinDistance">Maximum acceptable levenshtein distance between two strings</param>
        /// <returns>True if there is fuzzy match</returns>
        public bool IsMatch(string pattern, string stringToMatch, int maxLevenshteinDistance)
        {
            var tempObjectToCompare = stringToMatch?.Trim().ToLower();

            if (string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            var result =  _levenshteinDistanceService.GetLevenshteinDistance(pattern, tempObjectToCompare, maxLevenshteinDistance, true);
            return result.State == ResultState.Ok;
        }
    }
}