using chatapp.Data;
using chatapp.Infrastructure.Services;
using chatapp.Repositories;
using chatapp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using chatapp.Infrastructure.Options_Objects;

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

            // Add other services
            services.AddScoped<JWTTokenGenerator>();

            // Add controllers
            services.AddControllers();

            // Configure secrets
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("./secret.json", optional: false, reloadOnChange: true);
            var secretConfig = configBuilder.Build();
            services.Configure<JWTSettings>(secretConfig.GetSection("JWTSettings"));

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

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("JWTSettings:Issuer").Value,
                    ValidAudience = configuration.GetSection("JWTSettings:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(configuration.GetSection("JWTSettings:Secret").Value)),

                    // For some reason, the token was valid for additional time after it expired, the line below solved it
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["realtime-chatapp-access-token"];
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy("default", p =>
                {
                    p.RequireClaim("first_name");
                    p.RequireClaim("last_name");
                    p.RequireClaim("username");
                    p.RequireClaim("email");
                });
            });

            return services;
        }
    }
}
