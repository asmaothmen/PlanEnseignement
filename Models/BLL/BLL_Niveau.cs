using PlanEnseignement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.BLL
{
    public class BLL_Niveau
    {
        public static List<Niveau> GetAll()
        {
            return DAL_Niveau.SelectAll();
        }
    }
}
