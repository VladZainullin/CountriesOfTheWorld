using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
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
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var countries = await _repository.GetAllAsync(request.IncludeCities);
        return countries.Select(country => new CountryModel()
        {
            Name = country?.Name,
            Area = country.Area,
            Cities = country.Cities
            
        }).ToList();
    }
}