using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    public class EleveCommand
    {
        private readonly ContexteDA _contexte;

        public EleveCommand(ContexteDA contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajoute un élève
        /// </summary>
        /// <param name="eleve">Entité <see cref="Eleve"/></param>
        public void Add(Eleve eleve)
        {
            _contexte.Eleves.Add(eleve);
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifie un élève
        /// </summary>
        /// <param name="eleve">Entité <see cref="Eleve"/></param>
        public void Edit(Eleve eleve)
        {
            Eleve actualEleve = _contexte.Eleves.Where(e => e.EleveId == eleve.EleveId).SingleOrDefault();
            if (actualEleve != null)
            {
                actualEleve.Nom = eleve.Nom;
                actualEleve.Prenom = eleve.Prenom;
                actualEleve.DateNaissance = eleve.DateNaissance;
            }

            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprime un élève
        /// </summary>
        /// <param name="eleveId">Identifiant de l'élève</param>
        public void Delete(int eleveId)
        {
            Eleve eleve = _contexte.Eleves.Where(e => e.EleveId == eleveId).SingleOrDefault();
            if (eleve != null)
            {
                _contexte.Eleves.Remove(eleve);
                _contexte.SaveChanges();
            }
        }
    }
}
