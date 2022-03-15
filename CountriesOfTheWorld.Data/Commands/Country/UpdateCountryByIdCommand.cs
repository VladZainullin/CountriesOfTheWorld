using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record UpdateCountryByIdCommand(CountryModel Model, Guid Id) : IRequest<CountryModel>;