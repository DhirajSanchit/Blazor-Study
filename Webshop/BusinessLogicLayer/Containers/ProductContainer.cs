using System.Data.SqlClient;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces; 
using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;


namespace BusinessLogicLayer.Containers
{
    public class ProductContainer : IProductContainer
    {
        private bool result;
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

        public IEnumerable<Product> GetAllProducts(string? filter = null)
        {
            _products = new List<Product>();
            try
            {
                var dataset = _productDal.GetAllProducts();
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
                return _productDal.ArchiveProduct(id, DateTime.Now);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public List<SampleModel> GetAllSampleDto()
        {
            List<SampleModel> sampleData = new List<SampleModel>();
            try
            {
                var dataset = _productDal.getSampleData();
                foreach (var row in dataset)
                {
                    sampleData.Add(new SampleModel(row));
                }

                return sampleData;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public SampleModel? GetSampleDtoById(int id)
        {
            SampleModel sampleData;
            try
            {
                sampleData = new SampleModel(_productDal.getSampleDataById(id));
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                return sampleData = null;
            }   
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            return sampleData;
        }
    }
}