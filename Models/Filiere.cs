using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignement.Models
{
    public partial class Filiere
    {
        public Filiere()
        {
            Module = new HashSet<Module>();
            Parcours = new HashSet<Parcours>();
        }

        public string Code { get; set; }
        public string CodeTypeDiplome { get; set; }
        public string CodeDepartementTutelle { get; set; }
        public string CodeTypePeriodeEnseignement { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAr { get; set; }
        public string IntituleAbrege { get; set; }
        public string Domaine { get; set; }
        public string Mention { get; set; }
        public string PeriodeHabilitation { get; set; }
        public int? NombrePeriodes { get; set; }
        public int? NombreNiveaux { get; set; }

        public virtual UniteEnseignement UniteEnseignement { get; set; }
        public virtual ICollection<Module> Module { get; set; }
        public virtual ICollection<Parcours> Parcours { get; set; }
    }
}
