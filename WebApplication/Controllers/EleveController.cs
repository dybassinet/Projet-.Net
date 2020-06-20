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
    public class EleveController : Controller
    {
        // GET: Eleve
        public ActionResult Index()
        {
            List<Eleve> eleves = Manager.Instance.GetAllEleves();
            EleveAdapter eleveAdapter = new EleveAdapter();
            List<EleveViewModel> vms = eleveAdapter.ConvertToViewModels(eleves);
            return View(vms);
        }

        public ActionResult DetailEleve(int eleveId)
        {
            Eleve eleve = Manager.Instance.GetEleveById(eleveId);
            EleveAdapter eleveAdapter = new EleveAdapter();
            EleveViewModel vm = eleveAdapter.ConvertToViewModel(eleve);
            return PartialView("DetailEleve", vm);
        }
    }
}