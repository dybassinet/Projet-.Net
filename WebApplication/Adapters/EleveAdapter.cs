using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class EleveAdapter
    {
        public EleveViewModel ConvertToViewModel(Eleve eleve)
        {
            if (eleve == null)
            {
                return null;
            }

            var vm = new EleveViewModel
            {
                EleveId = eleve.EleveId,
                Nom = eleve.Nom,
                Prenom = eleve.Prenom,
                DateNaissance = eleve.DateNaissance,
                ClassId = eleve.ClassId
            };

            return vm;
        }

        public List<EleveViewModel> ConvertToViewModels(List<Eleve> eleves)
        {
            var vms = new List<EleveViewModel>();
            if (eleves == null)
            {
                return vms;
            }

            foreach (Eleve eleve in eleves)
            {
                var vm = new EleveViewModel
                {
                    EleveId = eleve.EleveId,
                    Nom = eleve.Nom,
                    Prenom = eleve.Prenom,
                    DateNaissance = eleve.DateNaissance,
                    ClassId = eleve.ClassId
                };

                vms.Add(vm);
            }

            return vms;
        }

        public void ConvertToEntity(Eleve entity, EleveViewModel vm)
        {
            entity.Nom = vm.Nom;
            entity.Prenom = vm.Prenom;
            entity.DateNaissance = vm.DateNaissance;
            entity.ClassId = vm.ClassId;
        }
    }
}