using System.Collections.Generic;
using Core.Entities;
using Core.Handlers;
using Xunit;

namespace CoreTests
{
    public class OptimizatorTests
    {
        public static IEnumerable<object[]> GetOptimizatorTestCases()
        {
            yield return new object[]
            {
                new Note { Numerator = 2, Denominator = 4},
                new Note { Numerator = 1, Denominator = 2}
            };
            yield return new object[]
            {
                new Note { Numerator = 1, Denominator = 2},
                new Note { Numerator = 1, Denominator = 2}
            };
            yield return new object[]
            {
                new Note { Numerator = 4, Denominator = 8},
                new Note { Numerator = 1, Denominator = 2}
            };
            yield return new object[]
            {
                new Note { Numerator = 8, Denominator = 16},
                new Note { Numerator = 1, Denominator = 2}
            };
        }

        [Theory]
        [MemberData(nameof(GetOptimizatorTestCases))]
        public void RunNoteOptimizeTests(Note input, Note expectedOptimized)
        {
            Optimizator.ExecuteForNote(input);
            Assert.True(input.Numerator == expectedOptimized.Numerator &&
                        input.Denominator == expectedOptimized.Denominator);
        }
    }
}
