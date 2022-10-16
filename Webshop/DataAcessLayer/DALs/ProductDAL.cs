using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAcessLayer.DALs
{
    public class ProductDAL : IProductDAL
    {
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
                throw ex;
            }
            
            
        }

        
        
        public IEnumerable<ProductDto> GetAllProducts(string filter)
        {
            List<ProductDto> list;
            try
            {
                if (string.IsNullOrWhiteSpace(filter))
                    list = dataAccess.Query<ProductDto, dynamic>("SELECT * FROM Product", new { });
                else
                    list = dataAccess.Query<ProductDto, dynamic>(
                        "SELECT * FROM Product WHERE Name like '%' + @Filter + '%'",
                        new { Filter = filter });

                return list.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}