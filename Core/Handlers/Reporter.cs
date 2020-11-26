using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Handlers
{
    public static class Reporter
    {
        public static string ExportToString(IList<ValidationResult> validationResults)
        {
            var reportMessage = new StringBuilder();
            for (int index = 0; index < validationResults.Count; index++)
            {
                var tactValidationResult = validationResults[index].IsValid
                    ? validationResults[index].Tact.InputValue
                    : Constants.Messages.TactError;

                reportMessage.Append(tactValidationResult);

                if (index < validationResults.Count - 1)
                {
                    reportMessage.Append(Constants.Delimiters.BetweenTacts);
                }
            }


            return reportMessage.ToString();
        }
    }
}
