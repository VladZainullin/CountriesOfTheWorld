using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public sealed record GetCityByCountryIdAndCityIdQuery(Guid CountryId, Guid CityId) : IRequest<CityModel>;