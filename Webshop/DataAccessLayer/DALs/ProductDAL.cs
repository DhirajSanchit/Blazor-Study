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
                return dataAccess.QuerySingle<ProductDto, dynamic>("SELECT * FROM Product WHERE ProductId = @ProductId",
                    new { ProductId = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public IEnumerable<ProductDto> GetAllProducts(string filter)
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
                        @"SELECT * FROM Product WHERE Name like '%' + @Filter + '%' AND WHERE ArchiveDate is null",
                        new { Filter = filter });

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
                string sql =
                    @"INSERT INTO [dbo].[Product]([Name],[Price],[Description],[ImageLink]) VALUES (@Name, @Price, @Description, @ImageLink)";
                var affectedRows = dataAccess.ExecuteCommand(sql, dto);
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
    }
}