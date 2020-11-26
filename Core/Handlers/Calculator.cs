using System;
using Core.Entities;

namespace Core.Handlers
{
    public static class Calculator
    {
        public static Note Execute(Tact tact)
        {
            var result = new Note();
            foreach (var current in tact.Notes)
            {
                if (result.Denominator == default)
                {
                    result.Numerator = current.Numerator;
                    result.Denominator = current.Denominator;

                    continue;
                }
                if (current.Denominator == result.Denominator)
                {
                    result.Numerator++;
                    continue;
                }

                LeadToCommonDenominator(result, current);
                result.Numerator += current.Numerator;
            }

            Optimizator.ExecuteForNote(result);
            return result;
        }

        private static void LeadToCommonDenominator(Note result, Note current)
        {
            int greatestCommonDivisior =
                Optimizator.FindGreatestCommonDivisior(result.Denominator, current.Denominator);
            var maxValue = Math.Max(result.Denominator, current.Denominator);
            var multiplyCoefficient = maxValue / greatestCommonDivisior;

            if (current.Denominator == maxValue)
            {
                LeadToCommonDenominator(result, multiplyCoefficient);
                return;
            }

            LeadToCommonDenominator(current, multiplyCoefficient);
        }

        private static void LeadToCommonDenominator(Note note, int multiplyCoefficient)
        {
            note.Numerator *= multiplyCoefficient;
            note.Denominator *= multiplyCoefficient;
        }
    }
}
