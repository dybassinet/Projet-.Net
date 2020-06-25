using BusinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Adapters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult OpenViewEditNote(int noteId, int eleveId)
        {
            if (noteId == 0) //CREATION
            {
                return PartialView("EditNote", new NoteViewModel { EleveId = eleveId });
            }

            NoteAdapter noteAdapter = new NoteAdapter();
            Note note = Manager.Instance.GetNoteById(noteId);
            NoteViewModel noteViewModel = noteAdapter.ConvertToViewModel(note);
            return PartialView("EditNote", noteViewModel);
        }

        public ActionResult EditNote(NoteViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //Notification erreur
                return View("EditNote", vm);
            }

            NoteAdapter noteAdapter = new NoteAdapter();
            EleveAdapter eleveAdapter = new EleveAdapter();
            if (vm.NoteId == 0)
            {
                Note note = new Note();
                noteAdapter.ConvertToEntity(note, vm);
                Manager.Instance.AddNote(note);
            }
            else
            {
                Note note = Manager.Instance.GetNoteById(vm.NoteId);
                noteAdapter.ConvertToEntity(note, vm);
                Manager.Instance.EditNote(note);
            }
            
            Eleve eleve = Manager.Instance.GetEleveById(vm.EleveId);
            EleveViewModel eleveVM = eleveAdapter.ConvertToViewModel(eleve);
            //Notification succes
            return RedirectToAction("DetailEleve", "Eleve", new { usePartial = false, eleveId = vm.EleveId });
            //return View("../Eleve/DetailEleve", eleveVM);
        }
    }
}