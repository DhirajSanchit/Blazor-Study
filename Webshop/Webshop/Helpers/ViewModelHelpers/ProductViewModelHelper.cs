using BusinessLogicLayer.Classes;
using Webshop.Models;

namespace Webshop.Helpers.ViewModelHelpers;

public class ProductViewModelHelper
{
    public static ProductViewModel ToProductViewModel(Product product)
    {
        //create a new product view model from the product
        return new ProductViewModel
        {
            Id = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageLink = product.ImageLink,
        };
    }
    
    public static List<ProductViewModel> ToProductViewModelList(List<Product> products)
    {
        //Someone gave code below via feedback, but I don't understand it
        //Will look into it later
        //return products.Select(ToProductViewModel).ToList();
        
        //create a new list of product view models from the list of products
        var productViewModels = new List<ProductViewModel>();
        foreach (var product in products)
        {
            productViewModels.Add(ToProductViewModel(product));
        }
        return productViewModels;
    }
    
    public static Product ToProduct(ProductViewModel productViewModel)
    {
        //create a new product from the product view model
        return new Product
        {
            ProductId = productViewModel.Id,
            Name = productViewModel.Name,
            Description = productViewModel.Description,
            Price = productViewModel.Price,
            ImageLink = productViewModel.ImageLink,
        };
    }

}