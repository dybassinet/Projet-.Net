using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class AbsenceAdapter
    {
        /// <summary>
        /// Converti une entité <see cref="Absence"/> en ViewModel <see cref="AbsenceViewModel"/>
        /// </summary>
        /// <param name="note">Entité <see cref="Absence"/></param>
        /// <returns>Objet ViewModel <see cref="AbsenceViewModel"/></returns>
        public AbsenceViewModel ConvertToViewModel(Absence absence)
        {
            if (absence == null)
            {
                return null;
            }

            var vm = new AbsenceViewModel
            {
                AbsenceId = absence.AbsenceId,
                Motif = absence.Motif,
                DateAbsence = absence.DateAbsence,
                EleveId = absence.EleveId
            };

            return vm;
        }

        /// <summary>
        /// Converti une liste d'entités <see cref="Absence"/> en liste de ViewModel <see cref="AbsenceViewModel"/>
        /// </summary>
        /// <param name="notes">Liste d'entités <see cref="Absence"/></param>
        /// <returns>Liste d'objets ViewModel <see cref="AbsenceViewModel"/></returns>
        public List<AbsenceViewModel> ConvertToViewModels(List<Absence> absences)
        {
            EleveAdapter eleveAdapter = new EleveAdapter();
            var vms = new List<AbsenceViewModel>();
            if (absences == null || absences.Count == 0)
            {
                return vms;
            }

            foreach (Absence absence in absences)
            {
                var vm = new AbsenceViewModel
                {
                    AbsenceId = absence.AbsenceId,
                    Motif = absence.Motif,
                    DateAbsence = absence.DateAbsence,
                    EleveId = absence.EleveId,
                };

                vms.Add(vm);
            }

            return vms;
        }

        /// <summary>
        /// Converti un Objet ViewModel <see cref="AbsenceViewModel"/> en entité <see cref="Absence"/>
        /// </summary>
        /// <param name="entity">Entité <see cref="Absence"/></param>
        /// <param name="vm">Objet ViewModel <see cref="AbsenceViewModel"/></param>
        public void ConvertToEntity(Absence entity, AbsenceViewModel vm)
        {
            entity.Motif = vm.Motif;
            entity.DateAbsence = vm.DateAbsence;
            entity.EleveId = vm.EleveId;
        }
    }
}