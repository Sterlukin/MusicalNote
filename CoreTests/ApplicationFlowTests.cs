using Core;
using Xunit;

namespace CoreTests
{
    public class ApplicationFlowTests
    {
        [Theory]
        [InlineData("2/4", "4 4 | 8 8 8 8", "4 4 | 8 8 8 8")]
        [InlineData("2/4", "4 4 | 8 8 4 | 8 4 8", "4 4 | 8 8 4 | 8 4 8")]
        [InlineData("2/4", "8 4 8 | 8 8 8 4 | 4 4", "8 4 8 | <Îøèáêà> | 4 4")]
        [InlineData("4/4", "4 4 | 4 4 4 4", " <Îøèáêà> | 4 4 4 4")]
        public void RunTests(string inputTactSize, string inputStaves,
            string expectedOutput)
        {
            var actualOutput = Processor.Execute(inputTactSize, inputStaves);
            Assert.True(string.Equals(expectedOutput, actualOutput));
        }
    }
}
