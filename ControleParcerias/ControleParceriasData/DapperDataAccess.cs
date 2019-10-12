using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
namespace ControleParceriasData
{
    public class DapperDataAccess
    {
        public static string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ControleParcerias"].ConnectionString;

        public static void ExecuteWhitoutReturn(string ProcedureNome, DynamicParameters param)
        {
            using(SqlConnection sqlconn = new SqlConnection(connectionstring))
            {
                sqlconn.Open();
                sqlconn.Execute(ProcedureNome, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static T ExecuteReturnScalar<T>(string ProcedureNome, DynamicParameters param = null)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionstring))
            {
                sqlconn.Open();
               return (T)Convert.ChangeType(sqlconn.Execute(ProcedureNome, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));
            }
        }

        public static void ExecuteWhitoutReturn<T>(string v, DynamicParameters dbArgs)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<T> ExecuteReturnList<T>(string ProcedureNome, DynamicParameters param = null)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionstring))
            {
                sqlconn.Open();
                return sqlconn.Query<T>(ProcedureNome, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public static IEnumerable<T> ExecuteCommandReturnList<T>(string Comando, DynamicParameters param = null)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionstring))
            {
                sqlconn.Open();
                return sqlconn.Query<T>(Comando, param, commandType: System.Data.CommandType.Text).ToList();
            }
        }


    }
}
