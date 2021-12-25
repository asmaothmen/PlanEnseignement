using Microsoft.AspNetCore.Mvc;
using PlanEnseignement.Models;
using PlanEnseignement.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            List<Module> modules = BLL_Module.GetAll();
            ViewBag.ListModules = modules;
            return View();
        }
    }
}
