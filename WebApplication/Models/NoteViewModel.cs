using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(AllowEmptyStrings = false, ErrorMessage = "La matière est requise")]
        public string Matiere { get; set; }

        /// <summary>
        /// Date de la note
        /// </summary>
        [Display(Name = "Date")]
        public DateTime DateNote { get; set; }

        /// <summary>
        /// Appréciation
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "L'appréciation est requise")]
        public string Appreciation { get; set; }

        /// <summary>
        /// Valeur de la note
        /// </summary>
        [Display(Name = "Note")]
        public int ValeurNote { get; set; }

        /// <summary>
        /// Identifiant de l'élève noté
        /// </summary>
        public int EleveId { get; set; }
    }
}