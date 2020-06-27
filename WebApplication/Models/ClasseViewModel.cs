using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ClasseViewModel
    {
        /// <summary>
        /// Identifiant de la classe
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Nom de l'établissement
        /// </summary>
        [Display(Name = "Nom de l'établissement")]
        public string NomEtablissement { get; set; }

        /// <summary>
        /// Niveau de la classe
        /// </summary>
        public string Niveau { get; set; }

        /// <summary>
        /// Collection d'élèves dans la classe
        /// </summary>
        public ICollection<EleveViewModel> Eleves { get; set; }
    }
}