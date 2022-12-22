using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;


namespace BusinessLogicLayer.Containers
{
    public class ProductContainer : IProductContainer
    {
        private IProductDAL _productDal;

        private IList<Product> _products;

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

        public IEnumerable<Product> GetAllAvailableProducts()
        {
            _products = new List<Product>();
            try
            {
                var dataset = _productDal.GetAllAvailableProducts();
                foreach (var row in dataset)
                {
                    _products.Add(new Product(row));
                }

                return _products.AsEnumerable();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public bool AddProduct(Product product)
        {
            try
            {
                return _productDal.AddProduct(product.toDto());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                return _productDal.UpdateProduct(product.toDto());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }


        public bool ArchiveProduct(int id)
        {
            try
            {
                return _productDal.HandleArchivation(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public IEnumerable<Product> SearchProducts(string? filter = null)
        {
            _products = new List<Product>();
            try
            {
                var dataset = _productDal.SearchProducts(filter);
                foreach (var row in dataset)
                {
                    _products.Add(new Product(row));
                }

                return _products.AsEnumerable();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public List<Product> GetAssortment()
        {
            _products = new List<Product>();
            try
            {
                var dataset = _productDal.GetAssortment();
                foreach (var row in dataset)
                {
                    _products.Add(new Product(row));
                }

                return _products.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}