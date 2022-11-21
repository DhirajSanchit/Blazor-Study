using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Components; 

namespace Webshop.Pages.App;

public partial class SearchBlazor
{
    
    public string SearchText = "";
    public List<Product> FilteredProducts { get; set; } = new List<Product>();

    [Inject]
    public IProductContainer? ProductContainer { get; set; }

    private void Search()
    {
        FilteredProducts.Clear();
        if (ProductContainer is not null)
        {
            if (SearchText.Length >= 3)
                FilteredProducts = ProductContainer.GetAllProducts(SearchText).ToList();
        }
    }

    public void OnGet()
    {
        
    }
}


