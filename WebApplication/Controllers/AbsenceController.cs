using BusinessLayer;
using Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication.Adapters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AbsenceController : Controller
    {
        public ActionResult OpenViewEditAbsence(int absenceId, int eleveId)
        {
            if (absenceId == 0) //CREATION
            {
                return View("EditAbsence", new AbsenceViewModel { EleveId = eleveId });
            }

            AbsenceAdapter absenceAdapter = new AbsenceAdapter();
            Absence absence = Manager.Instance.GetAbsenceById(absenceId);
            AbsenceViewModel absenceViewModel = absenceAdapter.ConvertToViewModel(absence);
            return View("EditAbsence", absenceViewModel);
        }

        /// <summary>
        /// Modifie ou crée une absence
        /// </summary>
        /// <param name="vm">Objet ViewModel <see cref="AbsenceViewModel"/></param>
        /// <returns></returns>
        public ActionResult EditAbsence(AbsenceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAbsence", vm);
            }

            AbsenceAdapter absenceAdapter = new AbsenceAdapter();
            EleveAdapter eleveAdapter = new EleveAdapter();
            if (vm.AbsenceId == 0) //Création
            {
                Absence absence = new Absence();
                absenceAdapter.ConvertToEntity(absence, vm);
                Manager.Instance.AddAbsence(absence);
            }
            else //Modification
            {
                Absence absence = Manager.Instance.GetAbsenceById(vm.AbsenceId);
                absenceAdapter.ConvertToEntity(absence, vm);
                Manager.Instance.EditAbsence(absence);
            }

            Eleve eleve = Manager.Instance.GetEleveById(vm.EleveId);
            EleveViewModel eleveVM = eleveAdapter.ConvertToViewModel(eleve);
            return RedirectToAction("DetailEleve", "Eleve", new { eleveId = vm.EleveId });
        }

        /// <summary>
        /// Supprime une absence
        /// </summary>
        /// <param name="absenceId">Identifiant de l'absence</param>
        /// <param name="eleveId">Identifiant de l'élève</param>
        /// <returns></returns>
        public ActionResult DeleteAbsence(int absenceId, int eleveId)
        {
            Manager.Instance.DeleteAbsence(absenceId);
            return RedirectToAction("DetailEleve", "Eleve", new { eleveId = eleveId });
        }

        public async Task<ActionResult> GetLastAbsences()
        {
            AbsenceAdapter absenceAdapter = new AbsenceAdapter();
            List<Absence> absences = await Manager.Instance.GetLastAbsences();
            List<AbsenceViewModel> vms = absenceAdapter.ConvertToViewModels(absences);
            return PartialView("LastAbsences", vms);
        }
    }
}