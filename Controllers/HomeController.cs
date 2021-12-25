using ClosedXML.Excel;

using iTextSharp.text;
using Microsoft.AspNetCore.Http.Extensions;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanEnseignement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using IronPdf;

namespace PlanEnseignement.Controllers
{
    public class HomeController : Controller
    {
        private PlanEnseignementContext Context = new PlanEnseignementContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public FileResult ExportToExcel()
        {
            DataTable dt = new DataTable("Filiere");
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("Code"),
                                                     new DataColumn("CodeTypeDiplome"),
                                                     new DataColumn("CodeDepartementTutelle"),
                                                     new DataColumn("CodeTypePeriodeEnseignement"),
                                                     new DataColumn("IntituleFr"),
                                                     new DataColumn("IntituleAr"),
                                                     new DataColumn("IntituleAbrege"),
                                                     new DataColumn("Domaine"),
                                                     new DataColumn("Mention"),
                                                     new DataColumn("PeriodeHabilitation"),
                                                     new DataColumn("NombrePeriodes"),
                                                     new DataColumn("NombreNiveaux")});

            var filieres = from Filiere in this.Context.Filiere select Filiere;
            foreach (var filiere in filieres)
            {
                dt.Rows.Add(filiere.Code, filiere.CodeTypeDiplome, filiere.CodeDepartementTutelle, filiere.CodeTypePeriodeEnseignement,
                    filiere.IntituleFr, filiere.IntituleAr, filiere.IntituleAbrege, filiere.Domaine, filiere.Mention,
                   filiere.PeriodeHabilitation, filiere.NombrePeriodes, filiere.NombreNiveaux);
            }
            DataTable dtParcours = new DataTable("Parcous");
            dtParcours.Columns.AddRange(new DataColumn[5] { new DataColumn("Code"),
                                                     new DataColumn("IntituleFr"),
                                                     new DataColumn("IntituleAr"),
                                                     new DataColumn("IntituleAbrege"),
                                                     new DataColumn("CodeFiliere") });

            var parcours = from Parcours in this.Context.Parcours select Parcours;
            foreach (var item in parcours)
            {
                dtParcours.Rows.Add(item.Code,
                    item.IntituleFr, item.IntituleAr, item.IntituleAbrege, item.CodeFiliere);
            }
            //Niveau
            DataTable dtNiveau = new DataTable("Niveau");
            
            dtNiveau.Columns.AddRange(new DataColumn[5]{
                                                     new DataColumn("Code"),
                                                     new DataColumn("IntituleFr"),
                                                     new DataColumn("IntituleAbrege"),
                                                     new DataColumn("CodeFiliere"),
                                                     new DataColumn("AnneeNiveau")});
            var niveaux = from Niveau in this.Context.Niveau select Niveau;
            foreach (var niveau in niveaux)
            {
                dtNiveau.Rows.Add(niveau.Code, niveau.IntituleFr, niveau.IntituleAbrege, niveau.CodeFiliere, niveau.AnneeNiveau);
            }
            //module
            DataTable dtModule = new DataTable("Module");
            dtModule.Columns.AddRange(new DataColumn[18] { new DataColumn("ID"),
                                                     new DataColumn("Code"),
                                                     new DataColumn("IdUniteEnseignement"),
                                                     new DataColumn("CodeFiliere"),
                                                     new DataColumn("CodeParcours"),
                                                     new DataColumn("CodeNiveau"),
                                                     new DataColumn("Periode"),
                                                     new DataColumn("IntituleFr"),
                                                     new DataColumn("IntituleAbrege"),
                                                     new DataColumn("Credits"),
                                                     new DataColumn("Coefficients"),
                                                     new DataColumn("UniteVolumeHoraire"),
                                                     new DataColumn("VolumeCours"),
                                                     new DataColumn("VolumeTd"),
                                                     new DataColumn("VolumeTp"),
                                                     new DataColumn("VolumeCi"),
                                                     new DataColumn("VolumeTutorat"),
                                                     new DataColumn("RegimeExamen")});

            var modules = from Module in this.Context.Module select Module;
            foreach (var module in modules)
            {
                dtModule.Rows.Add(module.Id, module.Code, module.IdUniteEnseignement, module.CodeFiliere, module.CodeParcours, module.CodeNiveau, module.Periode,
                    module.IntituleFr, module.IntituleAbrege, module.Credits, module.Coefficients,
                   module.UniteVolumeHoraire, module.VolumeCours, module.VolumeTd, module.VolumeTp, module.VolumeCi, module.VolumeTutorat, module.RegimeExamen);
            }
            //UnitéEnseignement
            DataTable dtUniteE = new DataTable("UnitéEnseignement");
            dtUniteE.Columns.AddRange(new DataColumn[8] { new DataColumn("ID"),
                                                     new DataColumn("Code"),
                                                     new DataColumn("CodeFiliere"),
                                                     new DataColumn("CodeParcours"),
                                                     new DataColumn("CodeNiveau"),
                                                     new DataColumn("Periode"),
                                                     new DataColumn("IntituleFr"),
                                                     new DataColumn("Nature"),
                                                    });

            var Unites = from UnitéEnseignement in this.Context.UniteEnseignement select UnitéEnseignement;
            foreach (var unite in Unites)
            {
                dtUniteE.Rows.Add(unite.Id, unite.Code, unite.CodeFiliere, unite.CodeParcours,
                    unite.CodeNiveau, unite.Periode, unite.IntituleFr, unite.Nature);
            }



            using (XLWorkbook wb = new XLWorkbook()) //Install ClosedXml from Nuget for XLWorkbook  
            {
               
                wb.Worksheets.Add(dt).Columns().AdjustToContents(); 
                wb.Worksheets.Add(dtParcours).Columns().AdjustToContents(); 
                wb.Worksheets.Add(dtNiveau).Columns().AdjustToContents();
                wb.Worksheets.Add(dtModule).Columns().AdjustToContents();
                wb.Worksheets.Add(dtUniteE).Columns().AdjustToContents();
                using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
                }
            }
        }
       

    }
}
