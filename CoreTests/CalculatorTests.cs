using System.Collections.Generic;
using Core.Entities;
using Core.Handlers;
using Xunit;

namespace CoreTests
{
    public class CalculatorTests
    {
        public static IEnumerable<object[]> GetCalculatorTestCases()
        {
            yield return new object[]
            {
                new Tact
                {
                    Notes = new List<Note>
                    {
                        new Note { Numerator = 1, Denominator = 4},
                        new Note { Numerator = 1, Denominator = 2}
                    }
                },
                new Note
                {
                    Numerator = 3, Denominator = 4
                }
            };
            yield return new object[]
            {
                new Tact
                {
                    Notes = new List<Note>
                    {
                        new Note { Numerator = 1, Denominator = 4},
                        new Note { Numerator = 1, Denominator = 4},
                        new Note { Numerator = 1, Denominator = 4}
                    }
                },
                new Note
                {
                    Numerator = 3,
                    Denominator = 4
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetCalculatorTestCases))]
        public void RunTactCalculateTests(Tact tact, Note expectedNote)
        {
            var actualNote = Calculator.Execute(tact);
            Assert.True(actualNote.Numerator == expectedNote.Numerator &&
                        actualNote.Denominator == expectedNote.Denominator);
        }
    }
}
