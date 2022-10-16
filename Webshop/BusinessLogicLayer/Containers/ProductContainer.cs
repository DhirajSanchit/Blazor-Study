using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces; 
using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;


namespace BusinessLogicLayer.Containers
{
    public class ProductContainer : IProductContainer
    {
        private IProductDAL _productDal;

        private IList<Product> _products;
        //private IEnumerable<Product> _products;

        public ProductContainer(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public Product GetProductById(int id)
        {
            Product Product;
            try
            {
                Product = new Product(_productDal.GetProductById(id));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            return Product;
        }

        public IEnumerable<Product> GetAllProducts(string? filter = null)
        {
            _products = new List<Product>();
            try
            {
                 var  dataset =  _productDal.GetAllProducts();
                 foreach (var row in dataset)
                 {
                     _products.Add(new Product(row));
                 }

                 return _products.AsEnumerable();

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

    }
}