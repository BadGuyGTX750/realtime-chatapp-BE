using chatapp.Data;
using chatapp.Repositories;
using chatapp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace chatapp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add services
            services.AddScoped<ContactService>();
            services.AddScoped<ConversationService>();
            services.AddScoped<GroupMemberService>();
            services.AddScoped<MessageService>();

            // Add repositories
            services.AddScoped<ContactRepository>();
            services.AddScoped<ConversationRepository>();
            services.AddScoped<GroupMemberRepository>();
            services.AddScoped<MessageRepository>();

            // Add controllers
            services.AddControllers();

            // Configure secrets
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("./secret.json", optional: false, reloadOnChange: true);
            var secretConfig = configBuilder.Build();

            // Configure Entity Framework
            services.AddDbContext<Entities>(options =>
            {
                options.UseSqlServer(secretConfig.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "realtime_chatapp API", Version = "v1.0.0" });
            });


            return services;
        }
    }
}
