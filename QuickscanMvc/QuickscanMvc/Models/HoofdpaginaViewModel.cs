namespace QuickscanMvc.Models
{
    public class HoofdpaginaViewModel
    {
        public List<SchoolgebouwViewModel> schoolgebouwViewModels { get; set; }
        public string DropdownValue { get; set; }
        public string FilterText { get; set; }
        public string GebruikerType { get; set; }
    }
}
