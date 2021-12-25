using PlanEnseignement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.BLL
{
    public class BLL_Filiere
    {
        public static List<Filiere> GetAll()
        {
            return DAL_Filiere.SelectAll();
        }
    }
}