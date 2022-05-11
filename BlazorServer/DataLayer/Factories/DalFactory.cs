namespace DataLayer.Factories;

public class DalFactory
{
    private readonly IServiceProvider _serviceProvider;


    public DalFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
}