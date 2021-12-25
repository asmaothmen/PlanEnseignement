using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignement.Models
{
    public partial class Niveau
    {
        public Niveau()
        {
            Module = new HashSet<Module>();
            UniteEnseignement = new HashSet<UniteEnseignement>();
        }

        public string Code { get; set; }
        public string CodeFiliere { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAbrege { get; set; }
        public int? AnneeNiveau { get; set; }

        public virtual ICollection<Module> Module { get; set; }
        public virtual ICollection<UniteEnseignement> UniteEnseignement { get; set; }
    }
}
