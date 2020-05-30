using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Queries
{
    public class ClasseQuery
    {
        private readonly ContexteDA _contexte;

        public ClasseQuery(ContexteDA monContexte)
        {
            _contexte = monContexte;
        }

        /// <summary>
        /// Retourne toutes les classes
        /// </summary>
        /// <returns>Liste d'entités <see cref="Classe"/></returns>
        public List<Classe> GetAll()
        {
            return _contexte.Classes.ToList();
        }

        /// <summary>
        /// Retourne la classe correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de la classe</param>
        /// <returns>Entité <see cref="Classe"/></returns>
        public Classe GetById(int id)
        {
            return _contexte.Classes.Where(c => c.ClassId == id).SingleOrDefault();
        }
    }
}
