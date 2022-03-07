using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record DeleteCountryByNameCommand(string Name) : IRequest<bool>;