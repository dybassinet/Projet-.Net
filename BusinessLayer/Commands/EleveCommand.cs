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
    }
}
