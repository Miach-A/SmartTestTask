using AutoMapper;
using MediatR;
using SmartTestTaskData;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var maperConfig = new MapperConfiguration(cfg =>
{
    // cfg.AddProfile<EquipmentPlacementContractMapperProfile>();
});

maperConfig.AssertConfigurationIsValid();
var mapper = maperConfig.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>();
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
