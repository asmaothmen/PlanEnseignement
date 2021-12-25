using Microsoft.AspNetCore.Mvc;
using PlanEnseignement.Models;
using PlanEnseignement.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Controllers
{
    public class UniteEnseignementController : Controller
    {
        public IActionResult Index()
        {
            List<UniteEnseignement> Unite = BLL_UniteEnseignement.GetAll();
            ViewBag.ListUniteEnseignement = Unite;
            return View();
        }
    }
}
