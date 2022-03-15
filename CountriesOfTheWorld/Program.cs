using FluentValidation.AspNetCore;
using CountriesOfTheWorld.Data.Context;
using CountriesOfTheWorld.Data.Services;
using CountriesOfTheWorld.Data.Validators.Country;
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

builder.Services.AddFluentValidation(ce =>
{
    ce.RegisterValidatorsFromAssembly(typeof(CityModelValidator).Assembly);
    ce.RegisterValidatorsFromAssembly(typeof(CountryModelValidator).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints
    => endpoints.MapControllers());

app.Run();