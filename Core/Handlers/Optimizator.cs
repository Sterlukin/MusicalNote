using System.Collections.Generic;
using Core.Entities;

namespace Core.Handlers
{
    public static class Optimizator
    {
        public static void ExecuteForNote(Note note)
        {
            var nodValue = FindGreatestCommonDivisior(note.Numerator, note.Denominator);

            note.Numerator /= nodValue;
            note.Denominator /= nodValue;
        }

        public static void ExecuteForTacts(IList<Tact> tacts)
        {
            foreach (var tact in tacts)
            {
                foreach (var note in tact.Notes)
                {
                    ExecuteForNote(note);
                }
            }
        }

        public static int FindGreatestCommonDivisior(int numerator, int denominator)
        {
            while (numerator != 0 && denominator != 0)
            {
                if (numerator % denominator > 0)
                {
                    var temp = numerator;
                    numerator = denominator;
                    denominator = temp % denominator;

                    continue;
                }

                break;
            }

            return denominator;
        }
    }
}
