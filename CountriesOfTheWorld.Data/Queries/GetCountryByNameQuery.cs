using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public record GetCountryByNameQuery(string name, bool includeCities) : IRequest<CountryModel>;