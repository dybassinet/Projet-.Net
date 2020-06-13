using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class NoteViewModel
    {
        /// <summary>
        /// Identifiant de la note
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Libellé de la matière
        /// </summary>
        public string Matiere { get; set; }

        /// <summary>
        /// Date de la note
        /// </summary>
        public DateTime DateNote { get; set; }

        /// <summary>
        /// Appréciation
        /// </summary>
        public string Appreciation { get; set; }

        /// <summary>
        /// Valeur de la note
        /// </summary>
        public int ValeurNote { get; set; }

        /// <summary>
        /// Identifiant de l'élève noté
        /// </summary>
        public int EleveId { get; set; }

        /// <summary>
        /// Elève noté
        /// </summary>
        //public EleveViewModel Eleve { get; set; }
    }
}