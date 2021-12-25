using PlanEnseignement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.BLL
{
    public class BLL_UniteEnseignement
    {
        public static List<UniteEnseignement> GetAll()
        {
            return DAL_UniteEnseignement.SelectAll();
        }
    }
}
