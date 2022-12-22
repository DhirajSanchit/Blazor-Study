using System.Xml;
using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAccessLayer.DALs
{
    public class ProductDAL : IProductDAL
    {
        private bool result = false;
        private readonly IDataAccess dataAccess;

        public ProductDAL(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ProductDto GetProductById(int id)
        {
            try
            {
                return dataAccess.QueryFirstOrDefault<ProductDto, dynamic>(
                    "SELECT * FROM Product WHERE ProductId = @ProductId",
                    new { ProductId = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public IEnumerable<ProductDto> GetAllAvailableProducts()
        {
            List<ProductDto> list;
            try
            {
                list = dataAccess.Query<ProductDto, dynamic>(@"SELECT * FROM [Product] WHERE ArchiveDate is null",
                    new { });
                return list.AsEnumerable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool AddProduct(ProductDto dto)
        {
            try
            {
                if (!CheckIfProductExists(dto))
                {

                    string sql =
                        @"INSERT INTO [dbo].[Product]([Name],[Price],[Description],[ImageLink]) VALUES (@Name, @Price, @Description, @ImageLink)";
                    var affectedRows = dataAccess.ExecuteCommand(sql, dto);
                    if (affectedRows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        public bool UpdateProduct(ProductDto dto)
        {
            try
            {
                string sql =
                    @"UPDATE [dbo].[Product] SET 
                           [Name] = @Name, 
                           [Price] = @Price, 
                           [Description] = @Description, 
                           [ImageLink] = @ImageLink 
                            WHERE ProductId = @ProductId";
                var affectedRows = dataAccess.ExecuteCommand(sql, dto);
                if (affectedRows > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        public bool HandleArchivation(int id)
        {
            try
            {
                if (IsArchived(id))
                {
                   result = UnArchiveProduct(id);
                } 
                else
                {
                    result = ArchiveProduct(id, DateTime.Now);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
            return result;
        }
        
        public bool ArchiveProduct(int id, DateTime archiveDate)
        {
            try
            {
                string sql = @"UPDATE [dbo].[Product] SET [ArchiveDate] = @ArchiveDate WHERE ProductId = @ProductId";
                var affectedRows = dataAccess.ExecuteCommand(sql, new { ArchiveDate = archiveDate, ProductId = id });
                if (affectedRows > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        private bool UnArchiveProduct(int id)
        {
            try
            {
                string sql = @"UPDATE [Product] SET [ArchiveDate] = NULL WHERE ProductId = @ProductId";
                var affectedRows = dataAccess.ExecuteCommand(sql, new {ProductId = id});
                if (affectedRows > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        public IEnumerable<ProductDto> SearchProducts(string filter = null)
        {
            List<ProductDto> list;
            try
            {
                if (string.IsNullOrWhiteSpace(filter))
                    list = dataAccess.Query<ProductDto, dynamic>(@"SELECT * FROM Product WHERE ArchiveDate is null",
                        new { });
                else
                    //TODO: Add filter, Revise Query
                    list = dataAccess.Query<ProductDto, dynamic>(
                        @"SELECT * FROM Product WHERE [Product].Name like '%'+@Filter+'%' AND ArchiveDate IS NULL",
                        new { Filter = filter });

                return list.AsEnumerable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private bool CheckIfProductExists(ProductDto dto)
        {
            try
            {
                //Query if product exists with all dto properties
                string sql =
                    @"SELECT COUNT(*) FROM Product WHERE Name = @ProductName AND Price = @Price AND Description = @Description";
                var param = new { ProductName = dto.Name, Price = dto.Price, Description = dto.Description };

                var product = dataAccess.QueryFirstOrDefault<ProductDto, dynamic>(sql, param);
                if (product != null)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return false;
        }

        public List<ProductDto> GetAssortment()
        {
            List<ProductDto> list;
            try
            {
                list = dataAccess.Query<ProductDto, dynamic>(@"SELECT * FROM Product",
                    new { });
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private bool IsArchived(int id)
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM Product WHERE ProductId = @ProductId AND ArchiveDate IS NOT NULL";
                var archived = dataAccess.QueryFirstOrDefault<int, dynamic>(sql, new { ProductId = id });

                if (archived > 0)
                    return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return false;
        }
    }
}