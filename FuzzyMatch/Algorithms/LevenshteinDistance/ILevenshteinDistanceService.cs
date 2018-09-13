namespace JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance
{
    public interface ILevenshteinDistanceService
    {
        Distance GetLevenshteinDistance(string pattern, string stringToMatch, int? maxDistance = null, bool ignoreCase = false);
    }
}