using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_Filiere
    {
        private static Filiere GetEntityFromDataRow(DataRow dataRow)
        {
            Filiere filiere = new Filiere();
            filiere.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            filiere.CodeDepartementTutelle = dataRow["CodeDepartementTutelle"] == DBNull.Value ? null : (string)dataRow["CodeDepartementTutelle"];
            filiere.CodeTypeDiplome = dataRow["CodeTypeDiplome"] == DBNull.Value ? null : (string)dataRow["CodeTypeDiplome"];
            filiere.CodeTypePeriodeEnseignement = dataRow["CodeTypePeriodeEnseignement"] == DBNull.Value ? null : (string)dataRow["CodeTypePeriodeEnseignement"];
            filiere.Domaine = dataRow["Domaine"] == DBNull.Value ? null : (string)dataRow["Domaine"];
            filiere.IntituleAbrege = dataRow["IntituleAbrege"] == DBNull.Value ? null : (string)dataRow["IntituleAbrege"];
            filiere.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            filiere.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            filiere.Mention = dataRow["Mention"] == DBNull.Value ? null : (string)dataRow["Mention"];
            filiere.PeriodeHabilitation = dataRow["PeriodeHabilitation"] == DBNull.Value ? null : (string)dataRow["PeriodeHabilitation"];
            filiere.NombreNiveaux = Convert.ToInt32(dataRow["NombreNiveaux"] == DBNull.Value ? null : dataRow["NombreNiveaux"]);
            filiere.NombrePeriodes = Convert.ToInt32(dataRow["NombrePeriodes"] == DBNull.Value ? null : dataRow["NombrePeriodes"]);
            return filiere;
        }
        private static List<Filiere> GetListFromDataTable(DataTable dt)
        {
            List<Filiere> list = new List<Filiere>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Filiere> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Filiere";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
