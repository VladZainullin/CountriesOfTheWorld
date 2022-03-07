using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record CreateCountryCommand(CountryModel Model) : IRequest<CountryModel>;