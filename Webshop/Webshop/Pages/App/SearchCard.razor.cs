using BusinessLogicLayer.Classes;
using Microsoft.AspNetCore.Components;

namespace Webshop.Pages.App;

public partial class SearchCard
{
        [Parameter]
        public Product? Product { get; set; }
}