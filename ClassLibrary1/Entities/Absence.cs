using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Absence
    {
        public int AbsenceId { get; set; }

        public DateTime DateAbsence { get; set; }

        public string Motif { get; set; }

        public int EleveId { get; set; }
    }
}
