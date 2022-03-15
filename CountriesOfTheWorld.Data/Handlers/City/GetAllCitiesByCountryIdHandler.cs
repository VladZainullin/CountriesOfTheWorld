using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class GetAllCitiesByCountryIdHandler : IRequestHandler<GetAllCitiesByCountryIdQuery, List<CityModel>>
{
    private readonly ICityRepository<Guid> _cityRepository;
    private readonly ICountryRepository<Guid> _countryRepository;

    public GetAllCitiesByCountryIdHandler(ICityRepository<Guid> cityRepository, ICountryRepository<Guid> countryRepository)
    {
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
    }
    
    public async Task<List<CityModel>> Handle(GetAllCitiesByCountryIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.CountryId, false);
        if (country is null)
        {
            throw new CountryException("Country not found");
        }
        
        var cities = await _cityRepository.GetAllByCountryId(request.CountryId);
        if (cities is null)
        {
            throw new CityException("Cities not found. Please create new city");
        }
        
        return cities.Select(city => new CityModel()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        }).ToList();
    }
}