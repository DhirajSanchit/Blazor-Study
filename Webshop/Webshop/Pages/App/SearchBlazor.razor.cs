using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Components; 

namespace Webshop.Pages.App;

public partial class SearchBlazor
{
    
    public string SearchQuery = "";
    public List<Product> FilteredProducts { get; set; } = new List<Product>();

    [Inject]
    public IProductContainer? ProductContainer { get; set; }

    private void Search()
    {
        try
        {
            FilteredProducts.Clear();
            if (ProductContainer is not null)
            {
                if (SearchQuery.Length >= 3)
                    FilteredProducts = ProductContainer.SearchProducts(SearchQuery).ToList();
            }
        }
        catch(NullReferenceException nre)
        {
            Console.WriteLine("No products found");
            SearchQuery = "";
        }
    }

    public void OnGet()
    {
        
    }
}


