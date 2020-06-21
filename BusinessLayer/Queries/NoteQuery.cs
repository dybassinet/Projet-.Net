using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Queries
{
    internal class NoteQuery
    {
        private readonly ContexteDA _contexte;

        public NoteQuery(ContexteDA monContexte)
        {
            _contexte = monContexte;
        }

        /// <summary>
        /// Retourne toutes les notes
        /// </summary>
        /// <returns>Liste d'entités <see cref="Note"/></returns>
        public List<Note> GetAll()
        {
            return _contexte.Notes.ToList();
        }

        /// <summary>
        /// Retourne la note correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de la note</param>
        /// <returns>Entité <see cref="Note"/></returns>
        public Note GetById(int id)
        {
            return _contexte.Notes.Where(n => n.NoteId == id).SingleOrDefault();
        }

        /// <summary>
        /// Retourne les notes correspondant à un élève
        /// </summary>
        /// <param name="eleveId">Identifiant de l'élève</param>
        /// <returns>Liste d'entités <see cref="Note"/></returns>
        public List<Note> GetByEleveId(int eleveId)
        {
            return _contexte.Notes.Where(n => n.EleveId == eleveId).ToList();
        }
    }
}
