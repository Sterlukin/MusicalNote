using System.Collections.Generic;
using Core.Entities;

namespace Core.Handlers
{
    public static class Validator
    {
        public static IList<ValidationResult> Compare(Note tactSize, IList<Tact> tacts)
        {
            var tactsValidationResult = new List<ValidationResult>();
            foreach (var tact in tacts)
            {
                var resultNoteOfTact = Calculator.Execute(tact);
                var isValidTact = resultNoteOfTact.Numerator == tactSize.Numerator &&
                                  resultNoteOfTact.Denominator == tactSize.Denominator;

                var tactValidationResult = new ValidationResult
                {
                    IsValid = isValidTact,
                    Tact = tact
                };
                tactsValidationResult.Add(tactValidationResult);
            }

            return tactsValidationResult;
        }
    }
}
