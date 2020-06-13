using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class AbsenceAdapter
    {
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

        public List<AbsenceViewModel> ConvertToViewModels(List<Absence> absences)
        {
            var vms = new List<AbsenceViewModel>();
            if (absences == null)
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
                    EleveId = absence.EleveId
                };

                vms.Add(vm);
            }

            return vms;
        }

        public void ConvertToEntity(Absence entity, AbsenceViewModel vm)
        {
            entity.Motif = vm.Motif;
            entity.DateAbsence = vm.DateAbsence;
            entity.EleveId = vm.EleveId;
        }
    }
}