using System.Collections.Generic;
using Core.Entities;

namespace Core.Handlers
{
    public static class Parser
    {
        public static Note ToNoteOrDefault(string noteString)
        {
            if (string.IsNullOrEmpty(noteString))
            {
                return null;
            }

            if (noteString.Contains(Constants.Delimiters.BetweenNoteParts))
            {
                return ParseFullNote(noteString);
            }

            return ParseCutNoteOrDefault(noteString);
        }

        public static IList<Tact> ToTacts(string noteStanString)
        {
            var tacts = new List<Tact>();
            var tactStrings = noteStanString.Split(Constants.Delimiters.BetweenTacts);

            foreach (var tactString in tactStrings)
            {
                var notesStringArray = tactString.Split(Constants.Delimiters.BetweenNotes);

                var notes = new List<Note>();
                foreach (var noteString in notesStringArray)
                {
                    var note = ToNoteOrDefault(noteString);
                    if (note != null)
                    {
                        notes.Add(note);
                    }
                }

                tacts.Add(new Tact
                {
                    InputValue = tactString,
                    Notes = notes
                });
            }

            return tacts;
        }

        private static Note ParseFullNote(string noteString)
        {
            var tact = noteString.Split(Constants.Delimiters.BetweenNoteParts);
            return new Note
            {
                Numerator = int.Parse(tact[0]),
                Denominator = int.Parse(tact[1])
            };
        }

        private static Note ParseCutNoteOrDefault(string noteString)
        {
            return new Note
            {
                Numerator = 1,
                Denominator = int.Parse(noteString)
            };
        }
    }
}
