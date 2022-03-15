using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record UpdateCityByCountryIdCommand(Guid CountryId, Guid CityId, CityModel Model) : IRequest<CityModel>;