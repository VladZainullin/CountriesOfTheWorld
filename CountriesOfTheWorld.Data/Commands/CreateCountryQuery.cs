using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using MediatR;

namespace CountriesOfTheWorld.Data.Commands;

public record CreateCountryQuery(CountryModel model) : IRequest<CountryModel>;