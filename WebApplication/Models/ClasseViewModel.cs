using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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