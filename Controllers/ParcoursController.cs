using Microsoft.AspNetCore.Mvc;
using PlanEnseignement.Models;
using PlanEnseignement.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Controllers
{
    public class ParcoursController : Controller
    {
        public IActionResult Index()
        {
            List<Parcours> parcours = BLL_Parcours.GetAll();
            ViewBag.ListParcours = parcours;
            return View();
        }
    }
}
