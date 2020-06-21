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

        public void Edit(Note note)
        {
            Note actualNote = _contexte.Notes.Where(n => n.NoteId == note.NoteId).SingleOrDefault();
            if (actualNote != null)
            {
                actualNote.DateNote = note.DateNote;
                actualNote.Matiere = note.Matiere;
                actualNote.ValeurNote = note.ValeurNote;
                actualNote.Appreciation = note.Appreciation;
            }

            _contexte.SaveChanges();
        }
    }
}
