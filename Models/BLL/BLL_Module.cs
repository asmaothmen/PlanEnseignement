using PlanEnseignement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.BLL
{
    public class BLL_Module
    {
        public static List<Module> GetAll()
        {
            return DAL_Module.SelectAll();
        }
    }
}
