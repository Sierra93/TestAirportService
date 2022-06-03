using Autofac;
using TestAirportService.Abstractions;
using TestAirportService.Abstractions.Attributes;

namespace TestAirportService.Services.AutofacModules
{
    /// <summary>
    /// Класс регистрации сервисов автофака.
    /// </summary>
    [CommonModule]
    public sealed class ServicesModule : Module
    {
        public static void InitModules(ContainerBuilder builder)
        {
            // Сервис аэропорта.
            builder.RegisterType<AirportService>().As<IAirportService>();
        }
    }
}