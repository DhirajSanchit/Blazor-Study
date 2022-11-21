using System.Data;
using System.Data.SqlClient;
using Dapper;
using InterfaceLayer.DALs;

namespace DataAccessLayer.DataAccess
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
            using IDbConnection conn = new SqlConnection(_connection);
            try
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                {
                    conn.Close();
                }
            }
        }

        public T QueryFirstOrDefault<T, U>(string sql, U parameters)
        {
            using IDbConnection conn = new SqlConnection(_connection);
            try
            {
                return conn.QueryFirstOrDefault<T>(sql, parameters);
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                {
                    conn.Close();
                }
            }
        }

        public int ExecuteCommand<T>(string sql, T parameters)
        {
            using IDbConnection conn = new SqlConnection(_connection);
            try
            {
                var affectedRows = conn.Execute(sql, parameters);
                Console.WriteLine($"Affected Rows: {affectedRows}");
                return affectedRows;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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