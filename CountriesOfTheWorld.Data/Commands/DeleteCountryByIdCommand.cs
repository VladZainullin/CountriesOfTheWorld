using CountriesOfTheWorld.Core.Entities;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record DeleteCountryByIdCommand(Guid Id) : IRequest<bool>;