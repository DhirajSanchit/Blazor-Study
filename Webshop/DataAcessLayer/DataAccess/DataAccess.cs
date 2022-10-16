using System.Data;
using System.Data.SqlClient;
using Dapper;
using InterfaceLayer.DALs;

namespace DataAcessLayer.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connection;

        public DataAccess(string connection)
        {
            this._connection = connection;
        }

        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(_connection))
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
            using (IDbConnection conn = new SqlConnection(_connection))
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
            using (IDbConnection conn = new SqlConnection(_connection))
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