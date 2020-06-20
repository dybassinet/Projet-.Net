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
    public class ClasseController : Controller
    {
        // GET: Classe
        public ActionResult Index()
        {
            List<Classe> classes = Manager.Instance.GetAllClasses();
            ClasseAdapter classeAdapter = new ClasseAdapter();
            List<ClasseViewModel> vms = classeAdapter.ConvertToViewModels(classes);
            return View(vms);
        }

        public ActionResult DetailClasse(int classId)
        {
            Classe classe = Manager.Instance.GetClasseById(classId);
            ClasseAdapter classeAdapter = new ClasseAdapter();
            ClasseViewModel vm = classeAdapter.ConvertToViewModel(classe);
            vm.Eleves = vm.Eleves.OrderBy(e => e.Nom).ToList();
            return PartialView("DetailClasse", vm);
        }
    }
}