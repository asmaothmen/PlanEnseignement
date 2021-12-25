using Microsoft.AspNetCore.Mvc;
using PlanEnseignement.Models;
using PlanEnseignement.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Controllers
{
    public class NiveauController : Controller
    {
        public IActionResult Index()
        {
            List<Niveau> niveaux = BLL_Niveau.GetAll();
            ViewBag.ListNiveaux = niveaux;
            return View();
        }
    }
}
