using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public record GetAllCitiesByCountryIdQuery(Guid CountryId) : IRequest<List<CityModel>>;