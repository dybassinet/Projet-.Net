using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    public class ClasseCommand
    {
        private readonly ContexteDA _contexte;

        public ClasseCommand(ContexteDA contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajoute une classe
        /// </summary>
        /// <param name="classe">Entité <see cref="Classe"/></param>
        public void Add(Classe classe)
        {
            _contexte.Classes.Add(classe);
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifie une classe
        /// </summary>
        /// <param name="classe">Entité <see cref="Classe"/></param>
        public void Edit(Classe classe)
        {
            Classe actualClasse = _contexte.Classes.Where(c => c.ClassId == classe.ClassId).SingleOrDefault();
            if (actualClasse != null)
            {
                actualClasse.Niveau = classe.Niveau;
                actualClasse.NomEtablissement = classe.NomEtablissement;
            }
        }

        /// <summary>
        /// Supprime une classe
        /// </summary>
        /// <param name="classeId">Identifiant de la classe</param>
        public void Delete(int classeId)
        {
            Classe classe = _contexte.Classes.Where(c => c.ClassId == classeId).SingleOrDefault();
            if (classe != null)
            {
                _contexte.Classes.Remove(classe);
                _contexte.SaveChanges();
            }
        }
    }
}
