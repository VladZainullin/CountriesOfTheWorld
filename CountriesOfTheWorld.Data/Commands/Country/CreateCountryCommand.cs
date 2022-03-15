using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record CreateCountryCommand(CountryModel Model) : IRequest<CountryModel>;