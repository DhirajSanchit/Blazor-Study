using BusinessLogicLayer.Classes;
using InterfaceLayer.Containers;
using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;


namespace BusinessLogicLayer.Containers
{
    public class ProductContainer : IProductContainer
    {
        private IProductDAL _productDal;

        private IEnumerable<ProductDto> _productsdtos;
        //private IEnumerable<Product> _products;

        public ProductContainer(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public ProductDto GetProductById(int id)
        {
            ProductDto productDto = new();
            try
            {
                productDto = _productDal.GetProductById(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return productDto;
        }

        public IEnumerable<ProductDto> GetAllProducts(string filter = null)
        {
            _productsdtos = _productDal.GetAllProducts();
            return _productsdtos;
        }

        // private IEnumerable<ProductDto> toProducts(IEnumerable<InterfaceLayer.Dtos.ProductDto> dataset)
        // {
        //     List<ProductDto> fetched = new();
        //     
        //     foreach (var dto in dataset)
        //     {
        //         new ProductDto(
        //             dto.ProductId,
        //             dto.Brand,
        //             dto.Name,
        //             dto.Price,
        //             dto.ImageLink,
        //             dto.Description);
        //     }
        //     return fetched.AsEnumerable();
        // }
        
        
    }
}