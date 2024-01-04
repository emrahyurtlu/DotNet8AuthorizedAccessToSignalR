
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net8Identity.Data;
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

            builder.Services.AddControllers();
            
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
            
            builder.Services.AddDbContext<ProdyumDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            
            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<ProdyumUser>()
                .AddEntityFrameworkStores<ProdyumDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<ProdyumUser>();

            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<MathHub>("/hubs/math-hub");

            app.Run();
        }
    }
}
