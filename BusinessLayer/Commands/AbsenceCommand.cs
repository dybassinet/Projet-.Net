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
    }
}
