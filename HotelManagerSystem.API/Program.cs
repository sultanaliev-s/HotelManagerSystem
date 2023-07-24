using System.Reflection;
using System.Text;
using HotelManagerSystem.API.AuthBL.Data;
using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Configs;
using HotelManagerSystem.API.Extensions;
using HotelManagerSystem.API.Handlers;
using HotelManagerSystem.API.Repositories;
using HotelManagerSystem.API.Service;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<Config>(provider => BindConfiguration(provider));

builder.Services.AddDbContext<HotelManagerSystemDb>();

builder.Services.AddDbContext<HotelContext>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<HotelContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IRepository<ErrorLog, int>, Repository<ErrorLog, int>>();
builder.Services.AddTransient<IRepository<HotelCategory, int>, Repository<HotelCategory, int>>();
builder.Services.AddTransient<IRepository<Country, int>, Repository<Country, int>>();
builder.Services.AddTransient<IRepository<City, int>, Repository<City, int>>();
builder.Services.AddTransient<IRepository<HotelType, int>, Repository<HotelType, int>>();
builder.Services.AddTransient<IRepository<HotelCategory, int>, Repository<HotelCategory, int>>();
builder.Services.AddTransient<IRepository<HotelServices, int>, Repository<HotelServices, int>>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();

builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<EmailManager>();
builder.Services.AddTransient<AuthManager>();
builder.Services.AddTransient<ChangePasswordManager>();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddTransient<RegisterUserHandler>();
builder.Services.AddTransient<CheckCodeHandler>();
builder.Services.AddTransient<LoginUserHandler>();
builder.Services.AddTransient<HotelCategoryServices>();
builder.Services.AddTransient<CountryServices>();
builder.Services.AddTransient<CityServices>();
builder.Services.AddTransient<HotelTypeServices>();
builder.Services.AddTransient<HotelCategoryServices>();
builder.Services.AddTransient<HotelServicesServices>();

builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
            ValidAudience = builder.Configuration["Jwt:Audience"]!,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });
builder.Services.AddAuthorization(options => options.DefaultPolicy =
    new AuthorizationPolicyBuilder
            (JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HotelManagerSystem API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });

});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string role = "Admin";
    if (!(await roleManager.RoleExistsAsync(role)))
    {
        await roleManager.CreateAsync(new IdentityRole(role));
    }
}

//if (app.Environment.IsDevelopment())
//{
//    
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelManagerSystem API v1");
});

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();

Config? BindConfiguration(IServiceProvider provider)
{
    var envName = builder.Environment.EnvironmentName;

    var config = new ConfigurationBuilder()
        .AddJsonFile($"appsettings.json")
        .Build();

    var configService = config.Get<Config>();
    return configService;
}
