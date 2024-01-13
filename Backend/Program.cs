
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net8Identity.Data;
using Net8Identity.Extensions;
using Net8Identity.Hubs;
using Swashbuckle.AspNetCore.Filters;

namespace Net8Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
            );

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            
            builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();
            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ApplyMigrations();
            }

            app.MapIdentityApi<ApplicationUser>();

            app.UseAuthentication();
            app.UseAuthorization();
            
            

            app.MapControllers();
            app.MapHub<MathHub>("/hubs/math-hub");

            app.Run();
        }
    }
}
