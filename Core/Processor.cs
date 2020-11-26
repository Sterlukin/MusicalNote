using System;
using Core.Handlers;

namespace Core
{
    public static class Processor
    {
        public static string Execute(string inputTactSize, string inputStaves)
        {
            try
            {
                var tactSize = Parser.ToNoteOrDefault(inputTactSize);
                var tacts = Parser.ToTacts(inputStaves);

                Optimizator.ExecuteForNote(tactSize);
                Optimizator.ExecuteForTacts(tacts);

                var validationResults = Validator.Compare(tactSize, tacts);
                return Reporter.ExportToString(validationResults);
            }
            catch (Exception ex)
            {
                return string.Format(Constants.Messages.OutputError, ex.Message);
            }
        }
    }
}
