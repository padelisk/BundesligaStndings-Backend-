
using BundesligaStndings_Backend_.Data.ExternalApi;
using BundesligaStndings_Backend_.Data.Repositories;
using BundesligaStndings_Backend_.Services;

namespace BundesligaStndings_Backend_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IFootballService, FootballService>();
            builder.Services.AddHttpClient<IFootballApiClient, OpenLigaDbClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Bundesliga API"));
            app.UseHttpsRedirection();

            


            app.MapControllers();

            app.Run();
        }
    }
}
