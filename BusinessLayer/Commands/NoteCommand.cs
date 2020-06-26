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

        /// <summary>
        /// Ajoute une note
        /// </summary>
        /// <param name="note">Entité <see cref="Note"/></param>
        public void Add(Note note)
        {
            _contexte.Notes.Add(note);
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifie une note
        /// </summary>
        /// <param name="note">Entité <see cref="Note"/></param>
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

        /// <summary>
        /// Supprime une note
        /// </summary>
        /// <param name="noteId">Identifiant de la note</param>
        public void Delete(int noteId)
        {
            Note note = _contexte.Notes.Where(n => n.NoteId == noteId).SingleOrDefault();
            _contexte.Notes.Remove(note);
            _contexte.SaveChanges();
        }
    }
}
