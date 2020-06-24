using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Queries
{
    internal class AbsenceQuery
    {
        private readonly ContexteDA _contexte;

        public AbsenceQuery(ContexteDA monContexte)
        {
            _contexte = monContexte;
        }

        /// <summary>
        /// Retourne toutes les absences
        /// </summary>
        /// <returns>Liste d'entités <see cref="Absence"/></returns>
        public List<Absence> GetAll()
        {
            return _contexte.Absences.ToList();
        }

        /// <summary>
        /// Retourne l'absence correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'absence</param>
        /// <returns>Entité <see cref="Absence"/></returns>
        public Absence GetById(int id)
        {
            return _contexte.Absences.Where(a => a.AbsenceId == id).SingleOrDefault();
        }

        /// <summary>
        /// Retourne les absences correspondant à un élève
        /// </summary>
        /// <param name="eleveId">Identifiant de l'élève</param>
        /// <returns>Liste d'entités <see cref="Absence"/></returns>
        public List<Absence> GetByEleveId(int eleveId)
        {
            return _contexte.Absences.Where(a => a.EleveId == eleveId).ToList();
        }

        /// <summary>
        /// Retourne les 5 dernières absences
        /// </summary>
        /// <returns></returns>
        public async Task<List<Absence>> GetLastAbsences()
        {
            //TODO : pas de pb mais pas assez optimisé (parfois l'affichage ne se fait pas car trop long)
            return await _contexte.Absences.OrderByDescending(e => e.DateAbsence).Take(5).ToListAsync();
        }
    }
}
