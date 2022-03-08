using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record UpdateCountryByNameCommand(CountryModel Model, string Name) : IRequest<CountryModel>;