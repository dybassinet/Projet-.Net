using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Absence
    {
        /// <summary>
        /// Identifiant de l'absence
        /// </summary>
        public int AbsenceId { get; set; }

        /// <summary>
        /// Date de l'absence
        /// </summary>
        public DateTime DateAbsence { get; set; }

        /// <summary>
        /// Motif de l'absence
        /// </summary>
        public string Motif { get; set; }

        /// <summary>
        /// Identifiant de l'élève absence
        /// </summary>
        public int EleveId { get; set; }

        /// <summary>
        /// Elève Absent
        /// </summary>
        public virtual Eleve Eleve { get; set; }
    }
}
