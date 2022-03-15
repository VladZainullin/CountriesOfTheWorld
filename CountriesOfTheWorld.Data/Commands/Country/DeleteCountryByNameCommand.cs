using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record DeleteCountryByNameCommand(string Name) : IRequest<bool>;