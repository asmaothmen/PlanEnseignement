using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_Module { 
   private static Module GetEntityFromDataRow(DataRow dataRow)
    {
        Module module = new Module();
            module.Id = (Guid) (dataRow["id"] == DBNull.Value ? null : dataRow["id"]);
            module.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
        module.IdUniteEnseignement = (long)(dataRow["IdUniteEnseignement"] == DBNull.Value ? null : dataRow["IdUniteEnseignement"]);
        module.CodeFiliere = dataRow["CodeFiliere"] == DBNull.Value ? null : (string)dataRow["CodeFiliere"];
        module.CodeParcours = dataRow["CodeParcours"] == DBNull.Value ? null : (string)dataRow["CodeParcours"];
        module.CodeNiveau = dataRow["CodeNiveau"] == DBNull.Value ? null : (string)dataRow["CodeNiveau"];
        module.Periode = Convert.ToInt32(dataRow["Periode"] == DBNull.Value ? null : dataRow["Periode"]);
        module.IntituleAbrege = dataRow["IntituleAbrege"] == DBNull.Value ? null : (string)dataRow["IntituleAbrege"];
        module.UniteVolumeHoraire = dataRow["UniteVolumeHoraire"] == DBNull.Value ? null : (string)dataRow["UniteVolumeHoraire"];
        module.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
        module.RegimeExamen = dataRow["RegimeExamen"] == DBNull.Value ? null : (string)dataRow["RegimeExamen"];
        module.VolumeCours = (float)(dataRow["VolumeCours"] == DBNull.Value ? null : dataRow["VolumeCours"]);

        module.VolumeCi = (float)(dataRow["VolumeCi"] == DBNull.Value ? null : dataRow["VolumeCi"]);
        module.VolumeTutorat = (float)(dataRow["VolumeTutorat"] == DBNull.Value ? null : dataRow["VolumeTutorat"]);
        module.VolumeTp = (float)(dataRow["VolumeTp"] == DBNull.Value ? null : dataRow["VolumeTp"]);
        module.VolumeTd = (float)(dataRow["VolumeTd"] == DBNull.Value ? null : dataRow["VolumeTd"]);
        module.Credits = (float)(dataRow["Credits"] == DBNull.Value ? null : dataRow["Credits"]);
        module.Coefficients = (float)(dataRow["Coefficients"] == DBNull.Value ? null : dataRow["Coefficients"]);
        return module;
    }
    private static List<Module> GetListFromDataTable(DataTable dt)
    {
        List<Module> list = new List<Module>();
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
                list.Add(GetEntityFromDataRow(dr));
        }
        return list;
    }
    public static List<Module> SelectAll()
    {
        DataTable dataTable;
        using (SqlConnection con = DbConnection.GetConnection())
        {
            con.Open();
            string StrSQL = "SELECT * FROM Module";
            SqlCommand command = new SqlCommand(StrSQL, con);
            dataTable = DataBaseAccessUtilities.SelectRequest(command);
        }
        return GetListFromDataTable(dataTable);
    }
}
}

