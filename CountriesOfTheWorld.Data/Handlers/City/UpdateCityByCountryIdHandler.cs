using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class UpdateCityByCountryIdHandler : IRequestHandler<UpdateCityByCountryIdCommand, CityModel>
{
    private readonly ICityRepository<Guid> _repository;
    private readonly ICountryRepository<Guid> _countryRepository;

    public UpdateCityByCountryIdHandler(ICityRepository<Guid> cityRepository, ICountryRepository<Guid> countryRepository)
    {
        _repository = cityRepository;
        _countryRepository = countryRepository;
    }
    
    public async Task<CityModel> Handle(UpdateCityByCountryIdCommand request, CancellationToken cancellationToken)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        
        var country = await _countryRepository.GetByIdAsync(request.CountryId, false);
        if (country is null)
        {
            throw new CountryException("Country not found");
        }
        
        var city = await _repository.GetByIdAsync(request.CityId);
        if (city is null)
        {
            throw new CityException("City not found");
        }
        
        city.Name = request.Model.Name;
        
        _repository.Update(city);
        await _repository.SaveChangesAsync();

        return new CityModel()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        };
    }
}