using RecenzjeFilmowe.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using RecenzjeFilmowe.Server.Interfaces;
using RecenzjeFilmowe.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using RecenzjeFilmowe.Server.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// app db context 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MS-SQL"));
});


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:5173", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFilmService, FilmService>();
builder.Services.AddTransient<IRecenzjaService, RecenzjaService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/film", ([FromServices] IFilmService FilmService) =>
{
    var film = FilmService.GetFilm();
    return Results.Ok(film);
});

app.MapGet("/film/{tytul:alpha}", ([FromRoute] string tytul,[FromServices] IFilmService FilmService) =>
{
    var film = FilmService.GetFilm(tytul);
    return Results.Ok(film);
});

app.MapGet("/film/{id:int}", ([FromRoute] int id, [FromServices] IFilmService FilmService) =>
{
    var film = FilmService.GetFilm(id);
    if (film is null) return Results.NotFound();
    return Results.Ok(film);
});

app.MapGet("/recenzja/{id:int}", ([FromRoute] int id, [FromServices] IRecenzjaService RecenzjaService) =>
{
    var recenzja = RecenzjaService.GetRecenzja(id);
    if (recenzja is null) return Results.NotFound();
    return Results.Ok(recenzja);
});

app.MapPost("/recenzja", ([FromBody] Recenzja recenzja, [FromServices] IRecenzjaService RecenzjaService) =>
{
    RecenzjaService.AddRecenzja(recenzja);
});

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
