using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignement.Models
{
    public partial class UniteEnseignement
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public string CodeFiliere { get; set; }
        public string CodeParcours { get; set; }
        public string CodeNiveau { get; set; }
        public int Periode { get; set; }
        public string Nature { get; set; }

        public virtual Filiere CodeFiliereNavigation { get; set; }
        public virtual Niveau CodeNiveauNavigation { get; set; }
        public virtual Parcours CodeParcoursNavigation { get; set; }
    }
}
