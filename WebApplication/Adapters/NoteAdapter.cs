using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class NoteAdapter
    {
        /// <summary>
        /// Converti une entité <see cref="Note"/> en ViewModel <see cref="NoteViewModel"/>
        /// </summary>
        /// <param name="note">Entité <see cref="Note"/></param>
        /// <returns>Objet ViewModel <see cref="NoteViewModel"/></returns>
        public NoteViewModel ConvertToViewModel(Note note)
        {
            if (note == null)
            {
                return null;
            }

            var vm = new NoteViewModel
            {
                NoteId = note.NoteId,
                Matiere = note.Matiere,
                Appreciation = note.Appreciation,
                DateNote = note.DateNote,
                ValeurNote = note.ValeurNote,
                EleveId = note.EleveId
            };

            return vm;
        }

        /// <summary>
        /// Converti une liste d'entités <see cref="Note"/> en liste de ViewModel <see cref="NoteViewModel"/>
        /// </summary>
        /// <param name="notes">Liste d'entités <see cref="Note"/></param>
        /// <returns>Liste d'objets ViewModel <see cref="NoteViewModel"/></returns>
        public List<NoteViewModel> ConvertToViewModels(List<Note> notes)
        {
            var vms = new List<NoteViewModel>();
            if (notes == null || notes.Count == 0)
            {
                return null;
            }

            foreach (Note note in notes)
            {
                var vm = new NoteViewModel
                {
                    NoteId = note.NoteId,
                    Matiere = note.Matiere,
                    Appreciation = note.Appreciation,
                    DateNote = note.DateNote,
                    ValeurNote = note.ValeurNote,
                    EleveId = note.EleveId
                };

                vms.Add(vm);
            }

            return vms;
        }

        /// <summary>
        /// Converti un Objet ViewModel <see cref="NoteViewModel"/> en entité <see cref="Note"/>
        /// </summary>
        /// <param name="entity">Entité <see cref="Note"/></param>
        /// <param name="vm">Objet ViewModel <see cref="NoteViewModel"/></param>
        public void ConvertToEntity(Note entity, NoteViewModel vm)
        {
            entity.Matiere = vm.Matiere;
            entity.Appreciation = vm.Appreciation;
            entity.DateNote = vm.DateNote;
            entity.ValeurNote = vm.ValeurNote;
            entity.EleveId = vm.EleveId;
        }
    }
}