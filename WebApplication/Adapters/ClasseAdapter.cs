using Model.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class ClasseAdapter
    {
        /// <summary>
        /// Converti une entité <see cref="Classe"/> en ViewModel <see cref="ClasseViewModel"/>
        /// </summary>
        /// <param name="note">Entité <see cref="Classe"/></param>
        /// <returns>Objet ViewModel <see cref="ClasseViewModel"/></returns>
        public ClasseViewModel ConvertToViewModel(Classe classe)
        {
            EleveAdapter eleveAdapter = new EleveAdapter();
            if (classe == null)
            {
                return null;
            }

            var vm = new ClasseViewModel
            {
                ClassId = classe.ClassId,
                NomEtablissement = classe.NomEtablissement,
                Niveau = classe.Niveau,
                Eleves = eleveAdapter.ConvertToViewModels(classe.Eleves.ToList())
            };

            return vm;
        }

        /// <summary>
        /// Converti une liste d'entités <see cref="Classe"/> en liste de ViewModel <see cref="ClasseViewModel"/>
        /// </summary>
        /// <param name="notes">Liste d'entités <see cref="Classe"/></param>
        /// <returns>Liste d'objets ViewModel <see cref="ClasseViewModel"/></returns>
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

        /// <summary>
        /// Converti un Objet ViewModel <see cref="ClasseViewModel"/> en entité <see cref="Classe"/>
        /// </summary>
        /// <param name="entity">Entité <see cref="Classe"/></param>
        /// <param name="vm">Objet ViewModel <see cref="ClasseViewModel"/></param>
        public void ConvertToEntity(Classe entity, ClasseViewModel vm)
        {
            entity.Niveau = vm.Niveau;
            entity.NomEtablissement = vm.NomEtablissement;
        }
    }
}