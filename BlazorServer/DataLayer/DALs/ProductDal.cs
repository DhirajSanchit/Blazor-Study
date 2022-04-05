using System.Data;
using Dapper;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace DataLayer.DALs;

public class ProductDal : IProductDal
{ 
    
        private IDbConnection _dbConnection;

        public ProductDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IList<ProductDto> GetAll()
        {
            var sql = @"select Name, Price, [Product].Description as Description, C.Description as Category
                        from  Product
                        LEFT JOIN dbo.Category C on C.CategoryId = Product.CategoryId";

            try
            {

                using (_dbConnection)
                {
                    // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                    var dataset = _dbConnection.Query<ProductDto>(sql).ToList();
                    return dataset;
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