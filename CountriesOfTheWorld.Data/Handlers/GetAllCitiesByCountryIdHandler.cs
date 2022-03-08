using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Queries;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class GetAllCitiesByCountryIdHandler : IRequestHandler<GetAllCitiesByCountryIdQuery, List<CityModel>>
{
    private readonly ICityRepository<Guid> _repository;

    public GetAllCitiesByCountryIdHandler(ICityRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<CityModel>> Handle(GetAllCitiesByCountryIdQuery request, CancellationToken cancellationToken)
    {
        var cities = await _repository.GetAllByCountryId(request.CountryId);
        return cities.Select(city => new CityModel()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        }).ToList();
    }
}