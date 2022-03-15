using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class GetCityByCountryIdAndCityId : IRequestHandler<GetCityByCountryIdAndCityIdQuery, CityModel>
{
    private readonly ICityRepository<Guid> _repository;
    private readonly ICountryRepository<Guid> _countryRepository;

    public GetCityByCountryIdAndCityId(ICityRepository<Guid> cityRepository, ICountryRepository<Guid> countryRepository)
    {
        _repository = cityRepository;
        _countryRepository = countryRepository;
    }
    
    public async Task<CityModel> Handle(GetCityByCountryIdAndCityIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.CountryId, false);
        if (country is null)
        {
            throw new CountryException("Country not found");
        }
        
        var city = await _repository.GetByIdAsync(request.CityId);
        if (city is null)
        {
            throw new CityException("Country not found");
        }

        return new CityModel()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        };
    }
}