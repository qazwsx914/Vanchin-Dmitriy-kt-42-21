using DmitriyVanchinKt_42_21.Interfaces.LecturersInterfaces;

namespace DmitriyVanchinKt_42_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILecturerService, LecturerService>();
            return services;
        }
    }
}
