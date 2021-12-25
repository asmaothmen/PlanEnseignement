using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DbConnection
    {
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PlanEnseignement;Data Source=DESKTOP-RIP3HIO\\SQLEXPRESS; Encrypt=True;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return cn;
        }
    }
}