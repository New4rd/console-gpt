namespace ConsoleGPT.Services;

public abstract class ServiceManager
{
    private static Dictionary<Type, IService> RegisteredServices { get; } = new();
    public static T? GetService<T>() where T : class
    {
        foreach (var service in RegisteredServices)
        {
            if (service.Key == typeof(T))
            {
                return service.Value as T;
            }
        }

        Console.WriteLine($"No service found with type: {typeof(T)}");
        return null;
    }

    public static void RegisterService(IService service, IServiceConfiguration configuration, bool autoInitialize = false)
    {
        if (RegisteredServices.Any(entry => entry.Key == service.GetType()))
        {
            return;
        }

        RegisteredServices.Add(service.GetType(), service);
        if (autoInitialize) service.Initialize(configuration);
    }
}