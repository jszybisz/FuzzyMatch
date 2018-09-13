using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using JacekSzybisz.FuzzyMatch.Algorithms.LevenshteinDistance;
using RandomStringCreator;
using Xunit;

namespace JacekSzybisz.FuzzyMatch.Tests
{
    public class LevenshteinDistanceServiceTests
    {
        LevenshteinDistanceService _service = new LevenshteinDistanceService();
        [Theory]
        [InlineData("HONDA", "HYUNDAI", 3)]
        [InlineData("FLOMAX", "VOLMAX", 3)]
        [InlineData("GILY", "GEELY", 2)]
        [InlineData("Match", "Match", 0)]
        [InlineData("1234567890", "!@#$%^&*()", 10)]
        public void GetLevenshteinDistance_DistanceShouldBeCorrect(string pattern, string phraseToMatch, int expectedDistance)
        {
            var result = _service.GetLevenshteinDistance(pattern, phraseToMatch);
            Assert.Equal(ResultState.Ok, result.State);
            Assert.Equal(expectedDistance, result.LevensteinDistance);
        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(false, 4)]
        public void GetLevenshteinDistance_IgnoreCaseShouldWork(bool ignoreCase, int expectedDistance)
        {
            var result = _service.GetLevenshteinDistance("HONDA", "Honda", null, ignoreCase);

            Assert.Equal(ResultState.Ok, result.State);
            Assert.Equal(expectedDistance, result.LevensteinDistance);
        }


        [Theory]
        [InlineData(0, ResultState.OutOfRange)]
        [InlineData(1, ResultState.OutOfRange)]
        [InlineData(2, ResultState.OutOfRange)]
        [InlineData(3, ResultState.OutOfRange)]
        [InlineData(4, ResultState.Ok)]
        [InlineData(5, ResultState.Ok)]
        [InlineData(null, ResultState.Ok)]
        public void GetLevenshteinDistance_MaxDistanceShouldWork(int? maxDistance, ResultState expectedState)
        {
            var result = _service.GetLevenshteinDistance("HONDA", "Honda", maxDistance);

            Assert.Equal(expectedState, result.State);
          
        }

        [Fact]
        public void GetLevenshteinDistance_Performance()
        {
            Random rnd = new Random();

            var randomStrings = new List<String>();
            for (int i = 0; i < 100; i++)
            {
                randomStrings.Add(new StringCreator().Get(50));
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
               
            for (int i =0; i < 100000; i++)
            {
                _service.GetLevenshteinDistance(randomStrings[rnd.Next(99)], randomStrings[rnd.Next(99)], 30);

            }
            stopwatch.Stop();
        
            Assert.True(stopwatch.Elapsed.TotalSeconds < 10);

        }
    }
}
