using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Eleve
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
        /// Classe
        /// </summary>
        public virtual Classe Classe { get; set; }

        /// <summary>
        /// Collection des notes de l'élève
        /// </summary>
        public virtual ICollection<Note> Notes { get; set; }

        /// <summary>
        /// Collection des absences de l'élève
        /// </summary>
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
