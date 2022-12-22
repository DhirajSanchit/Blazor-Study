using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace WebshopTests.Mocks.DALs;

public class ProductDALMock
{
    public static Mock<IProductDAL> GetProductDALMock()
    {
        #region ProductDto Stub

        var productDtos = new List<ProductDto>()
        {
            new ProductDto()
            {
                ProductId = 1,
                Name = "TestProduct",
                Price = 100,
                Description = "TestDescription",
                ImageLink = "TestImage"
            },
            new ProductDto()
            {
                ProductId = 2,
                Name = "Another Product",
                Price = 200,
                Description = "TestDescription2",
                ImageLink = "TestImage2"
            },
            new ProductDto()
            {
                ProductId = 3,
                Name = "Shirt",
                Price = 300,
                Description = "TestDescription3",
                ImageLink = "TestImage3"
            },
            new ProductDto()
            {
                ProductId = 4,
                Name = "Teacup",
                Price = 400,
                Description = "TestDescription4",
                ImageLink = "TestImage4"
            },
            new ProductDto()
            {
                ProductId = 5,
                Name = "Something Else",
                Price = 500,
                Description = "TestDescription5",
                ImageLink = "TestImage5"
            },
            new ProductDto()
            {
                ProductId = 6,
                Name = "Product 6",
                Price = 600,
                Description = "TestDescription6",
                ImageLink = "TestImage6"
            },
            new ProductDto()
            {
                ProductId = 7,
                Name = "Galaxy Tee",
                Price = 700,
                Description = "TestDescription7",
                ImageLink = "TestImage7"
            },
            new ProductDto()
            {
                ProductId = 8,
                Name = "Chair",
                Price = 800,
                Description = "TestDescription8",
                ImageLink = "TestImage8"
            },
            new ProductDto()
            {
                ProductId = 9,
                Name = "Manga",
                Price = 900,
                Description = "TestDescription9",
                ImageLink = "TestImage9"
            },
            new ProductDto()
            {
                ProductId = 10,
                Name = "Protein Shake",
                Price = 1000,
                Description = "TestDescription10",
                ImageLink = "TestImage10"
            },
        };

        #endregion

        var productDalMock = new Mock<IProductDAL>();

        //setup
        //set up the get all products method to return the list of productDtos matching the search string
        productDalMock.Setup(dal => dal.SearchProducts(It.IsAny<string>()))
            .Returns((string filter) => productDtos.FindAll(dto => dto.Name.Contains(filter)));


        // Setup the GetAllProducts method to return the list of productDtos
        productDalMock.Setup(x => x.GetAllAvailableProducts()).Returns(productDtos);

        //set up a mock for the method that gets a dto by id
        productDalMock.Setup(dal => dal.GetProductById(It.IsAny<int>()))
            .Returns((int id) => productDtos.FirstOrDefault(x => x.ProductId == id));

        //set up a mock for the method that adds a product
        productDalMock.Setup(dal => dal.AddProduct(It.IsAny<ProductDto>()))
            .Callback((ProductDto dto) => productDtos.Add(dto));

        //Logically, Methods below make sense, but cannot be tested because of the way the DTO is written
        // Dto's are not supposed to have setters by their designs.
        productDalMock.Setup(dal => dal.UpdateProduct(It.IsAny<ProductDto>())).Returns(true);
        productDalMock.Setup(dal => dal.ArchiveProduct(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(true);

        return productDalMock;
    }
}