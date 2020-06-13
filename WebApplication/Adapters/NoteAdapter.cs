using Model.Entities;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Adapters
{
    public class NoteAdapter
    {
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

        public List<NoteViewModel> ConvertToViewModels(List<Note> notes)
        {
            var vms = new List<NoteViewModel>();
            if (notes == null)
            {
                return vms;
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