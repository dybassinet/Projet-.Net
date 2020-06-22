using System.Collections.Generic;

namespace Model.Entities
{
    public class Classe
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
        public virtual ICollection<Eleve> Eleves { get; set; }

    }
}
