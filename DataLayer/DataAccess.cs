using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineShoppingWebApp.DataLayer
{
    public class DataAccess
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();
            }
        }
        // Method to add parameter
        public static SqlParameter AddParameter(string parameterName, object value, SqlDbType DbType, int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            //  param.Value = value.ToString();
            param.Value = value;
            param.SqlDbType = DbType;
            param.Size = size;
            param.Direction = ParameterDirection.Input;
            return param;
        }

        // Method to connect Store procedure to the Database
        public static DataTable ExcuteDTByProcedure(String ProcedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            try
            {
                adopter.Fill(dTable);
           
            }catch(Exception ex)
            {
            }
            finally
            {
                //Disposing objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }
    }
}