using TakeAwaySignalR.WebApi.DAL;
using TakeAwaySignalR.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dýþardan clientlera bu hub ý kullandýrmamý saðlýyacak
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});
builder.Services.AddSignalR();
builder.Services.AddDbContext<Context>();
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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

//localhost istekde bulunuyoruz 
//localhost:4356/api/signalrhub gitmesini saðlýyor bunun içindeki receiverlarý alýcak


app.Run();
