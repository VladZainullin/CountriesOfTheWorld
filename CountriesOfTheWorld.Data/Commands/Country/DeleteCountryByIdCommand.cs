using CountriesOfTheWorld.Core.Entities;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record DeleteCountryByIdCommand(Guid Id) : IRequest<bool>;