using BusinessLayer;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Adapters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ClasseController : Controller
    {
        /// <summary>
        /// Retourne la vue index des classes (liste des classes)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Classe> classes = Manager.Instance.GetAllClasses();
            ClasseAdapter classeAdapter = new ClasseAdapter();
            List<ClasseViewModel> vms = classeAdapter.ConvertToViewModels(classes);
            return View(vms);
        }

        /// <summary>
        /// Retourne la vue de détail d'une classe
        /// </summary>
        /// <param name="classId">Identifiant de la classe</param>
        /// <returns></returns>
        public ActionResult DetailClasse(int classId)
        {
            Classe classe = Manager.Instance.GetClasseById(classId);
            ClasseAdapter classeAdapter = new ClasseAdapter();
            ClasseViewModel vm = classeAdapter.ConvertToViewModel(classe);
            vm.Eleves = vm.Eleves.OrderBy(e => e.Nom).ToList();
            return View("DetailClasse", vm);
        }
    }
}