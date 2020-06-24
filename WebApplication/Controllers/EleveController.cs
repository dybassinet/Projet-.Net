using BusinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Adapters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EleveController : Controller
    {
        
        /// <summary>
        /// Retourne la vue index avec la liste des élèves
        /// </summary>
        /// <param name="criterias">critères de recherche</param>
        /// <returns></returns>
        public ActionResult Index(String criterias)
        {
            List<Eleve> eleves = Manager.Instance.GetAllEleves(criterias);
            EleveAdapter eleveAdapter = new EleveAdapter();
            List<EleveViewModel> vms = eleveAdapter.ConvertToViewModels(eleves);
            return View(vms);
        }

        /// <summary>
        /// Affiche la vue de détail d'un élève
        /// </summary>
        /// <param name="eleveId"></param>
        /// <returns></returns>
        public ActionResult DetailEleve(bool usePartial, int eleveId)
        {
            Eleve eleve = Manager.Instance.GetEleveById(eleveId);
            EleveAdapter eleveAdapter = new EleveAdapter();
            EleveViewModel vm = eleveAdapter.ConvertToViewModel(eleve);
            //vm.Moyenne = vm.Notes.Average(n => n.ValeurNote);
            if (usePartial)
            {
                return PartialView("DetailEleve", vm);
            }

            return View("DetailEleve", vm);
        }

        /// <summary>
        /// Retourne la vue avec les meilleurs élèves
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetBestEleves()
        {
            List<Eleve> eleves = await Manager.Instance.GetBestEleves();
            EleveAdapter eleveAdapter = new EleveAdapter();
            List<EleveViewModel> vms = eleveAdapter.ConvertToViewModels(eleves);
            return PartialView("BestEleves", vms);
        }
    }
}