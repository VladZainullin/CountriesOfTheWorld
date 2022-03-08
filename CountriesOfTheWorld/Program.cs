

using CountriesOfTheWorld.Data.Context;
using CountriesOfTheWorld.Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(typeof(CountryRepository).Assembly);

builder.Services.AddScoped<ICountryRepository<Guid>, CountryRepository>();
builder.Services.AddScoped<ICityRepository<Guid>, CityRepository>();

builder.Services.AddDbContext<CountriesOfTheWorldDbContext>(
    opt => opt.UseSqlite("Data Source=database.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();