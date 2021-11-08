using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using API.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<PresenceTracker>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}