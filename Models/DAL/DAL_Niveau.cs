using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_Niveau
    {
        private static Niveau GetEntityFromDataRow(DataRow dataRow)
        {
            Niveau niveau = new Niveau();
            niveau.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            niveau.CodeFiliere = dataRow["CodeFiliere"] == DBNull.Value ? null : (string)dataRow["CodeFiliere"];
            niveau.AnneeNiveau = Convert.ToInt32(dataRow["AnneeNiveau"] == DBNull.Value ? null : dataRow["AnneeNiveau"]);
            niveau.IntituleAbrege = dataRow["IntituleAbrege"] == DBNull.Value ? null : (string)dataRow["IntituleAbrege"];
            niveau.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];

            return niveau;
        }
        private static List<Niveau> GetListFromDataTable(DataTable dt)
        {
            List<Niveau> list = new List<Niveau>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Niveau> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Niveau";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
