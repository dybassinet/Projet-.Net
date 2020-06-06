using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    public class NoteCommand
    {
        private readonly ContexteDA _contexte;

        public NoteCommand(ContexteDA contexte)
        {
            _contexte = contexte;
        }

        public void Add(Note note)
        {
            _contexte.Notes.Add(note);
            _contexte.SaveChanges();
        }
    }
}
