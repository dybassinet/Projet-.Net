using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
        /// <param name="criterias">critères de recherche</param>
        /// <returns>Liste d'entités <see cref="Eleve"/></returns>
        public List<Eleve> GetAll(string criterias)
        {
            IQueryable<Eleve> query = _contexte.Eleves;
            if (!string.IsNullOrEmpty(criterias))
            {
                query = query.Where(e => e.Nom.ToUpper().Contains(criterias.ToUpper()) || e.Prenom.ToUpper().Contains(criterias.ToUpper()));
            }

            return query.OrderBy(e => e.Nom).ToList();
        }

        /// <summary>
        /// Retourne l'élève correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Entité <see cref="Eleve"/></returns>
        public Eleve GetById(int id)
        {
            return _contexte.Eleves.Where(e => e.EleveId == id).Include(m => m.Absences)
                                                               .Include(m => m.Notes).SingleOrDefault();
        }

        /// <summary>
        /// Retourne les 5 meilleurs élèves
        /// </summary>
        /// <returns></returns>
        public async Task<List<Eleve>> GetBestEleves()
        {
            //TODO : pas de pb mais pas assez optimisé (parfois l'affichage ne se fait pas car trop long)
            IQueryable<Eleve> query = _contexte.Eleves;
            query = query.OrderByDescending(e => e.Notes.Count != 0 ? e.Notes.Average(n => n.ValeurNote) : 0).Take(5);
            return await query.Include(e => e.Notes).ToListAsync();
        }
    }
}
