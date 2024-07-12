using Microsoft.Extensions.Options;
using System.Reflection;
using TakeAwayNight.Catalog.Services.CategoryServices;
using TakeAwayNight.Catalog.Services.FeaturesServices;
using TakeAwayNight.Catalog.Services.ProductServices;
using TakeAwayNight.Catalog.Services.SliderServices;
using TakeAwayNight.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ISliderServices, SliderServices>();
builder.Services.AddScoped<IFeaturesServices, FeaturesServices>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    //DatabaseSettings i�indeki de�erlere ula�acak
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
