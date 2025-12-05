using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

//CORS. Antingen skriver man egna policy eller usecors
builder.Services.AddCors();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(c =>
{
   c.AllowAnyHeader()
   .AllowAnyMethod()
   .AllowCredentials() //denna
   .AllowAnyOrigin(); //och denna är inte tillåtna tsm i azure? 11.56
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
