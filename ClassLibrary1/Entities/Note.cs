using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Note
    {
        public int NoteId { get; set; }

        public string Matiere { get; set; }

        public DateTime DateNote { get; set; }

        public string Appreciation { get; set; }

        public int valeurNote { get; set; }

        public int EleveId { get; set; }
    }
}
