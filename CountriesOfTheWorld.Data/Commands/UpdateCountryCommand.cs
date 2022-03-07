using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record class UpdateCountryCommand(CountryModel Model, Guid Id) : IRequest<CountryModel>;