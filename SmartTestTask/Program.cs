using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTestTask.Common.Mappings.Profiles;
using SmartTestTaskData;
using System.Reflection;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
