using System.Data;
using System.Data.SqlClient;
using Dapper;
using InterfaceLayer.DALs;

namespace DataAcessLayer.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    return conn.Query<T>(sql, parameters).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    {
                        conn.Close();
                    }
                }
            }
        }

        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    return conn.QuerySingle<T>(sql, parameters);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void ExecuteCommand<T>(string sql, T parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Execute(sql, parameters);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}