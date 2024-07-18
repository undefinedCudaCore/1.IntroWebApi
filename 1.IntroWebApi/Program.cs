
//Servers
//Application/development server: Kestrel
//Reverse Proxy Servers: (Used in Production): Nginx, Apache, IIS

//Real world scenario:
//Internet->Http->IIS/NGINX/APACHE->Kestrel->AppCode
//Kestrel does not support: Load balancing, SSL Cert decryption,  url rewrite, decompresion of requests etc.
using _1.IntroWebApi.Data;
using _1.IntroWebApi.Database;
using _1.IntroWebApi.Services;
using _1.IntroWebApi.Services.Repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //Services are IoC/DI container which we fill with services
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Registering DbContext
        builder.Services.AddDbContext<FoodDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCOnnection"));
        });

        builder.Services.AddCors(p => p.AddPolicy("corsfordevelopment", builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }));

        //Registering services for dependency injection
        //DI helps us instancetiate an object depending on our requested abstraction
        //Singelton creates a SINGLE instance of a class for the life time of the application
        builder.Services.AddSingleton<IFoodStoreService, FoodStoreService>();
        //builder.Services.AddSingleton<IFoodExpiryService, FoodExpiryService>();

        //Scoped creates a SINGLE instance of a class for each request
        builder.Services.AddScoped<IFoodExpiryService, FoodExpiryService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IFoodMapper, FoodMapper>();

        //------------------------------------------------------------------------------------------

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("corsfordevelopment");

        app.UseAuthorization();

        app.MapControllers();
        //app.MapGet("/first", () => "Hello world");

        app.Run();
    }
}