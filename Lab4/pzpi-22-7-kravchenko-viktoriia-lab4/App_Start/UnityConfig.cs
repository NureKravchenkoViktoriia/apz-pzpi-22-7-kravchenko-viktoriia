using Unity;
using Unity.Lifetime;
using AquaTrack.Services;
using AquaTrack.Repositories;
using AquaTrack.Data.Models;
using System.Web.Http;
using Unity.WebApi;

public static class UnityConfig
{
    public static void RegisterComponents(HttpConfiguration config)
    {
        var container = new UnityContainer();

        // Реєстрація сервісів
        container.RegisterType<IoTDeviceService>(new HierarchicalLifetimeManager());
        container.RegisterType<LimitService>(new HierarchicalLifetimeManager());
        container.RegisterType<UserService>(new HierarchicalLifetimeManager());
        container.RegisterType<WaterUsageService>(new HierarchicalLifetimeManager());

        // Реєстрація репозиторіїв
        container.RegisterType<IRepository<IoTDevice>, IoTDeviceRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<IRepository<Limit>, LimitRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<IRepository<User>, UserRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<IRepository<WaterUsage>, WaterUsageRepository>(new HierarchicalLifetimeManager());

        // Налаштування Dependency Resolver для Web API
        config.DependencyResolver = new UnityDependencyResolver(container);
    }
}
