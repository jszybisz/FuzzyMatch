namespace JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance
{
    public class Distance
    {
        private Distance()
        {
            
        }
        public ResultState State { get; protected set; }
        public int? LevensteinDistance { get; protected set; }

        public static Distance Ok(int distance)
        {
            return new Distance() {State = ResultState.Ok, LevensteinDistance = distance};
        }

        public static Distance OutOfRange()
        {
            return new Distance() { State = ResultState.OutOfRange };
        }
    }
}
