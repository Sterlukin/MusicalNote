using System.Collections.Generic;

namespace Core.Entities
{
    public class Tact
    {
        public string InputValue { get; set; }
        public IList<Note> Notes { get; set; }
    }
}
