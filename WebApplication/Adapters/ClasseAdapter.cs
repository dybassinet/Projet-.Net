using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class ClasseAdapter
    {
        public ClasseViewModel ConvertToViewModel(Classe classe)
        {
            if (classe == null)
            {
                return null;
            }

            var vm = new ClasseViewModel
            {
                ClassId = classe.ClassId,
                NomEtablissement = classe.NomEtablissement,
                Niveau = classe.Niveau
            };

            return vm;
        }

        public List<ClasseViewModel> ConvertToViewModels(List<Classe> classes)
        {
            var vms = new List<ClasseViewModel>();
            if (classes == null)
            {
                return vms;
            }
            
            foreach (Classe classe in classes)
            {
                var vm = new ClasseViewModel
                {
                    ClassId = classe.ClassId,
                    NomEtablissement = classe.NomEtablissement,
                    Niveau = classe.Niveau
                };

                vms.Add(vm);
            }

            return vms;
        }

        public void ConvertToEntity(Classe entity, ClasseViewModel vm)
        {
            entity.Niveau = vm.Niveau;
            entity.NomEtablissement = vm.NomEtablissement;
        }
    }
}