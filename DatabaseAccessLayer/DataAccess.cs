using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseAccessLayer
{
    public class DataAccess
    {
        private string ConnectionName { get; set; } = "DefaultConnection";

        public SqlConnection GetConnection()
        {
            string cnstr = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }

        public int ExecuteCommand(string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            int rc;
            using (SqlConnection cn = GetConnection())
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    // assign parameters passed in to the command
                    PopulateCommandParameters(cmd, procParameters);
                    rc = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return rc;
        }

        /// <summary>
        /// Populate Command Parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="procParameters"></param>
        private void PopulateCommandParameters(SqlCommand cmd, Dictionary<string, SqlParameter> procParameters)
        {
            foreach (var procParameter in procParameters)
            {
                cmd.Parameters.Add(procParameter.Value);
            }
        }
    }
}
