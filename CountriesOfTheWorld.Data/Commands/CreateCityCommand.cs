using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record CreateCityCommand(Guid CountryId, CityModel CityModel) : IRequest<CityModel>;