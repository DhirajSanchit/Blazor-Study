using BusinessLogicLayer.Classes;
using Webshop.Models;

namespace Webshop.Helpers.ViewModelHelpers;

public class AssortmentViewModelHelper
{
    public static AssortmentViewModel ToAssortmentViewModel(Product product)
    {   
        //TODO: Implement
        AssortmentViewModel model = new AssortmentViewModel();
        model.Id = product.ProductId;
        model.Name = product.Name;
        model.Description = product.Description;
        model.Price = product.Price;
        model.ImageLink = product.ImageLink;
        model.ArchiveDate = product.ArchiveDate;
        
        if(product.ArchiveDate != null)
        {
            model.TextLayout = "text-danger";
            model.BorderLayout = "border-danger";
        }
        else
        {
            model.TextLayout = "text-success";
            model.BorderLayout = "border-success";
        }

        return model;
    }
    
    public static List<AssortmentViewModel> ToAssortmentViewModelList(List<Product> products)
    {
        //for each product in products, call ToAssortmentViewModel(product)
        //and add the result to a list
        //return the list
        
        List<AssortmentViewModel> modelList = new List<AssortmentViewModel>();
        foreach (var product in products)
        {
            modelList.Add(ToAssortmentViewModel(product));
        }
        return modelList;
    } 
    public AssortmentViewModelHelper()
    {
        
    }
}