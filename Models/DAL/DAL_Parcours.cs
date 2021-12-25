using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_Parcours
    {
        private static Parcours GetEntityFromDataRow(DataRow dataRow)
        {
            Parcours parcours = new Parcours();
            parcours.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            parcours.CodeFiliere = dataRow["CodeFiliere"] == DBNull.Value ? null : (string)dataRow["CodeFiliere"];
            parcours.IntituleAbrege = dataRow["IntituleAbrege"] == DBNull.Value ? null : (string)dataRow["IntituleAbrege"];
            parcours.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            parcours.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];

            return parcours;
        }
        private static List<Parcours> GetListFromDataTable(DataTable dt)
        {
            List<Parcours> list = new List<Parcours>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Parcours> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Parcours ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}