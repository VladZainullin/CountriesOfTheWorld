using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public record GetCountryByIdQuery(Guid id, bool includeCities) : IRequest<CountryModel>;