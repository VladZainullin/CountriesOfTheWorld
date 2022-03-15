using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public sealed record DeleteCityByCountryIdCommand(Guid CityId) : IRequest<bool>;