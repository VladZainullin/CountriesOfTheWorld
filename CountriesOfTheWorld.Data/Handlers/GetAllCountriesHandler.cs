using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public sealed class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, List<CountryModel>>
{
    private readonly ICountryRepository<Guid> _repository;

    public GetAllCountriesHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<CountryModel>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _repository.GetAllAsync(request.IncludeCities);
        if (countries == null)
        {
            throw new CountryException("Countries not found. Please, create new country");
        }
        
        return countries
            .Select(country => new CountryModel()
        {
            Name = country?.Name,
            Area = country.Area,
            Cities = country.Cities
            
        })
            .OrderBy(c => c.Name)
            .ToList();
    }
}