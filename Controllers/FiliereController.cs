using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using PlanEnseignement.Models;
using PlanEnseignement.Models.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Controllers
{

    public class FiliereController : Controller
    {

     

        public IActionResult Index()
        {
            List<Filiere> filieres = BLL_Filiere.GetAll();
            ViewBag.ListFiliere = filieres;
            return View();
        }

        //[HttpPost]
    }
}
