using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_UniteEnseignement
    {
        private static UniteEnseignement GetEntityFromDataRow(DataRow dataRow)
        {
            UniteEnseignement Unite = new UniteEnseignement();
            Unite.Id = (Guid)(dataRow["id"] == DBNull.Value ? null : dataRow["id"]);
            Unite.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            Unite.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            Unite.CodeFiliere = dataRow["CodeFiliere"] == DBNull.Value ? null : (string)dataRow["CodeFiliere"];
            Unite.CodeParcours = dataRow["CodeParcours"] == DBNull.Value ? null : (string)dataRow["CodeParcours"];
            Unite.CodeNiveau = dataRow["CodeNiveau"] == DBNull.Value ? null : (string)dataRow["CodeNiveau"];
            Unite.Periode = Convert.ToInt32(dataRow["Periode"] == DBNull.Value ? null : dataRow["Periode"]);
            Unite.Nature = dataRow["Nature"] == DBNull.Value ? null : (string)dataRow["Nature"];
            return Unite;
        }
        private static List<UniteEnseignement> GetListFromDataTable(DataTable dt)
        {
            List<UniteEnseignement> list = new List<UniteEnseignement>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<UniteEnseignement> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM UniteEnseignement";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
