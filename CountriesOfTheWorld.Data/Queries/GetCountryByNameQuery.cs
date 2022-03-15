using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public sealed record GetCountryByNameQuery(string name, bool includeCities) : IRequest<CountryModel>;