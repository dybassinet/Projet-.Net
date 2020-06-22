using System;

namespace Model.Entities
{
    public class Note
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
        public virtual Eleve Eleve { get; set; }
    }
}
