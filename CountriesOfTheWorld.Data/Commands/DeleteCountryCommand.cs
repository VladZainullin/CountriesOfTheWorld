using CountriesOfTheWorld.Core.Entities;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record DeleteCountryCommand(Guid Id, bool includeCities) : IRequest<bool>;