using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AbsenceViewModel
    {
        /// <summary>
        /// Identifiant de l'absence
        /// </summary>
        public int AbsenceId { get; set; }

        /// <summary>
        /// Date de l'absence
        /// </summary>
        [Display(Name = "Date d'absence")]
        public DateTime DateAbsence { get; set; }

        /// <summary>
        /// Motif de l'absence
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le motif est requis")]
        public string Motif { get; set; }

        /// <summary>
        /// Identifiant de l'élève absence
        /// </summary>
        public int EleveId { get; set; }

        /// <summary>
        /// Elève Absent
        /// </summary>
        public string IdentiteEleve { get; set; }
    }
}