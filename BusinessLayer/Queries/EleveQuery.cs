using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer.Queries
{
    internal class EleveQuery
    {
        private readonly ContexteDA _contexte;

        public EleveQuery(ContexteDA monContexte)
        {
            _contexte = monContexte;
        }

        /// <summary>
        /// Retourne tous les élèves
        /// </summary>
        /// <returns>Liste d'entités <see cref="Eleve"/></returns>
        public List<Eleve> GetAll()
        {
            return _contexte.Eleves.OrderBy(e => e.Nom).ToList();
        }

        /// <summary>
        /// Retourne l'élève correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Entité <see cref="Eleve"/></returns>
        public Eleve GetById(int id)
        {
            return _contexte.Eleves.Where(e => e.EleveId == id).Include(m => m.Absences).Include(m => m.Notes).SingleOrDefault();
        }
    }
}
