using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    public class AbsenceCommand
    {
        private readonly ContexteDA _contexte;

        public AbsenceCommand(ContexteDA contexte)
        {
            _contexte = contexte;
        }

        public void Add(Absence absence)
        {
            _contexte.Absences.Add(absence);
            _contexte.SaveChanges();
        }

        public void Edit(Absence absence)
        {
            Absence actualAbsence = _contexte.Absences.Where(abs => abs.AbsenceId == absence.AbsenceId).SingleOrDefault();
            if (actualAbsence != null)
            {
                actualAbsence.DateAbsence = absence.DateAbsence;
                actualAbsence.Motif = absence.Motif;
            }

            _contexte.SaveChanges();
        }

        public void Delete(int absenceId)
        {
            Absence absence = _contexte.Absences.Where(abs => abs.AbsenceId == absenceId).SingleOrDefault();
            _contexte.Absences.Remove(absence);
        }
    }
}
