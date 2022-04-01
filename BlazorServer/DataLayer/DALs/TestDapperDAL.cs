using System.Data;
using Dapper;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace DataLayer.DALs
{
    public class TestDal : ITestDal
    {
        
        private IDbConnection _dbConnection;
        
        public TestDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public IList<TestDto> GetAllTestData()
        {
            var sql = @"SELECT [id], [value] FROM [Test]";

            try
            {

                using (_dbConnection)
                {
                    // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                    var tests = /*(IList<TestDto>)*/ _dbConnection.Query<TestDto>(sql).ToList();
                    return tests;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message); 
                throw new Exception(ex.Message);
            }
        }
        
    }
}