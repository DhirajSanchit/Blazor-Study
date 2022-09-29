using System.ComponentModel.DataAnnotations;

namespace BlazorServer.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerCity { get; set; }

        [Required]
        public string CustomerProvince { get; set; }

        [Required]
        public string CustomerCountry { get; set; }        
    }
}
