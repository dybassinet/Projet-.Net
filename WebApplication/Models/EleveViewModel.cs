using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EleveViewModel
    {
        /// <summary>
        /// Identifiant de l'élève
        /// </summary>
        public int EleveId { get; set; }

        /// <summary>
        /// Nom de l'élève
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de l'élève
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Date de naissance de l'élève
        /// </summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// Identifiant de la classe
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Moyenne de l'élève
        /// </summary>
        public double Moyenne { get; set; }

        /// <summary>
        /// Classe
        /// </summary>
        //public ClasseViewModel Classe { get; set; }

        /// <summary>
        /// Collection des notes de l'élève
        /// </summary>
        public ICollection<NoteViewModel> Notes { get; set; }

        /// <summary>
        /// Collection des absences de l'élève
        /// </summary>
        public ICollection<AbsenceViewModel> Absences { get; set; }
    }
}