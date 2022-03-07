using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Queries;

public sealed record GetAllCountriesQuery(bool IncludeCities) : IRequest<List<CountryModel>>;