using System.Collections.Generic;
using Core.Entities;
using Core.Handlers;
using Xunit;

namespace CoreTests
{
    public class ReporterTest
    {
        public static IEnumerable<object[]> GetReporterTestCases()
        {
            yield return new object[]
            {
                new List<ValidationResult>
                {
                    new ValidationResult
                    {
                        IsValid = true,
                        Tact = new Tact
                        {
                            InputValue = "4 2",
                            Notes = new List<Note>
                            {
                                new Note { Numerator = 1, Denominator = 4},
                                new Note { Numerator = 1, Denominator = 2}
                            }
                        },
                    },
                    new ValidationResult
                    {
                        IsValid = true,
                        Tact = new Tact
                        {
                            InputValue = "2 4",
                            Notes = new List<Note>
                            {
                                new Note { Numerator = 1, Denominator = 2},
                                new Note { Numerator = 1, Denominator = 4}
                            }
                        },
                    },
                },
                "4 2|2 4"
            };
            yield return new object[]
            {
                new List<ValidationResult>
                {
                    new ValidationResult
                    {
                        IsValid = true,
                        Tact = new Tact
                        {
                            InputValue = "2 2",
                            Notes = new List<Note>
                            {
                                new Note { Numerator = 1, Denominator = 2},
                                new Note { Numerator = 1, Denominator = 2}
                            }
                        },
                    },
                    new ValidationResult
                    {
                        IsValid = false,
                        Tact = new Tact
                        {
                            InputValue = "2 4",
                            Notes = new List<Note>
                            {
                                new Note { Numerator = 1, Denominator = 2},
                                new Note { Numerator = 1, Denominator = 4}
                            }
                        },
                    },
                },
                "2 2| <Ошибка> "
            };
        }

        [Theory]
        [MemberData(nameof(GetReporterTestCases))]
        public void RunStringReportTests(IList<ValidationResult> validationResults, string expectedReport)
        {
            var actualReport = Reporter.ExportToString(validationResults);
            Assert.True(string.Equals(expectedReport, actualReport));
        }
    }
}
