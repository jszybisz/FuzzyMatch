namespace JacekSzybisz.FuzzyMatch
{
    /// <summary>
    /// Service that peforms fuzzy search
    /// </summary>
    public interface IFuzzyMatchProvider
    {
      

    

        /// <summary>
        /// Checks if there is fuzzy match between strings. Sum of DoubleMetaphone and Levenshatein distance to evaluate value
        /// </summary>
        /// <param name="pattern">Pattern to match</param>
        /// <param name="stringToMatch">string that shoudl match pattern</param>
        /// <param name="maxLevenshteinDistance">Maximum acceptable levenshtein distance between two strings</param>
        /// <returns>True if there is fuzzy match</returns>
        bool IsMatch(string pattern, string stringToMatch, int maxLevenshteinDistance);
    }
}