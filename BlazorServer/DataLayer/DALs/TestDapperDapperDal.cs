using System.Data;
using Dapper;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace DataLayer.DALs
{
    public class TestDapperDapperDal : ITestDapperDal
    {
        
        private IDbConnection _dbConnection;
        
        public TestDapperDapperDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public List<TestDto> GetAllTestData()
        {
            var sql = @"SELECT [id], [value] FROM [Test]";

            try
            {

                using (_dbConnection)
                {
                    // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                    var tests = _dbConnection.Query<TestDto>(sql).ToList();
                    return tests;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.Close();
            }
        }
        
    }
}
