using BusinessLayer;
using Model.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Adapters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AbsenceController : Controller
    {
        // GET: Absence
        public ActionResult AjoutAbsence(int eleveId)
        {
            return PartialView(new AbsenceViewModel { EleveId = eleveId });
        }

        public ActionResult CreerAbsence(AbsenceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //Notification erreur
                return PartialView("AjoutAbsence", vm);
            }

            AbsenceAdapter absenceAdapter = new AbsenceAdapter();
            EleveAdapter eleveAdapter = new EleveAdapter();
            Absence absence = new Absence();
            absenceAdapter.ConvertToEntity(absence, vm);
            Manager.Instance.AddAbsence(absence);
            Eleve eleve = Manager.Instance.GetEleveById(vm.EleveId);
            EleveViewModel eleveVM = eleveAdapter.ConvertToViewModel(eleve);
            //Notification succes
            return View("../Eleve/DetailEleve", eleveVM);
        }

        public ActionResult GetLastAbsences()
        {
            AbsenceAdapter absenceAdapter = new AbsenceAdapter();
            List<Absence> absences = Manager.Instance.GetLastAbsences();
            List<AbsenceViewModel> vms = absenceAdapter.ConvertToViewModels(absences);
            return PartialView("LastAbsences", vms);
        }
    }
}