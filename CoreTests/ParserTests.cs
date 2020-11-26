using System.Collections.Generic;
using Core.Entities;
using Core.Handlers;
using Xunit;

namespace CoreTests
{
    public class ParserTests
    {
        public static IEnumerable<object[]> GetParserTestCases()
        {
            yield return new object[]
            {
                "1/2", new Note { Numerator = 1, Denominator = 2}
            };
            yield return new object[]
            {
                "1/4", new Note { Numerator = 1, Denominator = 4}
            };
            yield return new object[]
            {
                "1/8", new Note { Numerator = 1, Denominator = 8}
            };
            yield return new object[]
            {
                "1/16", new Note { Numerator = 1, Denominator = 16}
            };
            yield return new object[]
            {
                "2/4", new Note { Numerator = 2, Denominator = 4}
            };
            yield return new object[]
            {
                "2/8", new Note { Numerator = 2, Denominator = 8}
            };
            yield return new object[]
            {
                "2/16", new Note { Numerator = 2, Denominator = 16}
            };
        }

        [Theory]
        [MemberData(nameof(GetParserTestCases))]
        public void RunNoteParseTests(string input, Note expected)
        {
            var actual = Parser.ToNoteOrDefault(input);
            Assert.True(expected.Numerator == actual.Numerator &&
                        expected.Denominator == actual.Denominator);
        }
    }
}