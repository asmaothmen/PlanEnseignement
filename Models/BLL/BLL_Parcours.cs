using PlanEnseignement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.BLL
{
    public class BLL_Parcours
    {
        public static List<Parcours> GetAll()
        {
            return DAL_Parcours.SelectAll();
        }
    }
}
