using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record UpdateCountryByNameCommand(CountryModel Model, string Name) : IRequest<CountryModel>;