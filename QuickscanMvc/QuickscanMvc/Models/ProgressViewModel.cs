namespace QuickscanMvc.Models;

public class ProgressViewModel
{
    public string Color;
    public int ColorId;
    public List<string> names { get; set; }
    public IDictionary<string, int> categories = new Dictionary<string, int>();    
    public double progress { get; set; }
    
    public string[] colors = new string[] { 
        "bg-primary", 
        "bg-secondary", 
        "bg-success", 
        "bg-danger", 
        "bg-warning",
        "bg-info",
        "bg-light",
        "bg-dark"
    }; 
    
    
}