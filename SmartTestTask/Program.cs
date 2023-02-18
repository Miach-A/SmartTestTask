using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartTestTask.Common.Mappings.Profiles;
using SmartTestTaskData;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json")
 .AddUserSecrets(Assembly.GetExecutingAssembly())
 .Build();


var maperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<EquipmentPlacementContractMapperProfile>();
});

maperConfig.AssertConfigurationIsValid();
var mapper = maperConfig.CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("Sql"));
});

builder.Services.AddAuthentication("OAuth")
    .AddJwtBearer("OAuth", config =>
    {
        byte[] secretBytes = Encoding.UTF8.GetBytes(builder.Configuration["Auth:SecretKey"] ?? "");
        var key = new SymmetricSecurityKey(secretBytes);

        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["Auth:Issuer"],
            ValidAudience = builder.Configuration["Auth:Audience"],
            IssuerSigningKey = key
        };

        config.Events = new JwtBearerEvents
        {
            OnMessageReceived = (context) =>
            {
                var access_token = context.Request.Query["access_token"];

                if (!string.IsNullOrEmpty(access_token))
                {
                    context.Token = access_token;
                }

                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert token",
        Name = "access_token",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        new List<string>(){ }
        }
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
