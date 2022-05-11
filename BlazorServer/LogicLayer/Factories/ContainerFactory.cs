namespace LogicLayer.Factories;

public class ContainerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ContainerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}