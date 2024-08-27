using _1._IntroWebApi.Services;
using _1.IntroWebApi.Data;
using _1.IntroWebApi.Services;
using IntroWebApi.Infrastructure.Database;
using IntroWebApi.Infrastructure.Extencions;
using IntroWebApi.Infrastructure.Services.Repositories;
using IntroWepApi.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace _1._IntroWebApi
{
    // Servers
    // Application/development server: Kestrel
    // Reverse Proxy Servers: (Used in Production): Nginx, Apache, IIS

    // Real world scenario:
    // Internet->Http->IIS/Nginx/Apache->Kestrel->AppCode
    // Kestrel is required to form HttpContext
    // Kestrel does not support: Load balancing, SSL Cert decryption, url rewrite, decompresion of requests etc

    // IIS Express is used to simulate IIS
    public class Program
    {
        public static void Main(string[] args)
        {
            // Builder can load configuration settings(connString), environment (env settings(API Urls, server name etc), default services(Predefined or developer created services)
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
            // Services are IoC/DI container which we fill with services
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = "JWT Authorization",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "bearer",
            //        BearerFormat = "JWT"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            }
            //        },
            //        new string[] {}
            //    }
            //});
            //});

            //var jwtSettings = builder.Configuration.GetSection("Jwt");
            //var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidIssuer = jwtSettings["Issuer"],
            //        ValidAudience = jwtSettings["Audience"]
            //    };
            //});



            // Registering DbContext

            builder.Services.AddDbContext<FoodDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Create CORS policy
            builder.Services.AddCors(p => p.AddPolicy("corsfordevelopment", builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            builder.Services.AddCors(p => p.AddPolicy("ProductionCorsPolicy", builder =>
            {
                builder.WithOrigins("https://wwww.google.com", "http://logalhost:4050")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));

            // Registering services for Dependency Injection
            // DI helps us instantiate an object depending on our requested abstraction
            // Singleton creates a SINGLE instance of a class for the lifetime of the application
            builder.Services.AddSingleton<IFoodStoreService, FoodStoreService>();
            builder.Services.AddSingleton<IJwtService, JwtService>();

            // Scoped creates a SINGLE instance of a class for for each request
            builder.Services.AddScoped<IFoodExpiryService, FoodExpiryService>();
            // -------------------------------------------------
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            builder.Services.AddScoped<IFoodMapper, FoodMapper>();

            builder.Services.AddBusinessServices();
            builder.Services.AddDatabaseServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("corsfordevelopment");
            }
            else
            {
                app.UseCors("ProductionCorsPolicy");
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            // app.MapGet("/first", () => "Hello World!");


            app.Run();
        }
    }
}