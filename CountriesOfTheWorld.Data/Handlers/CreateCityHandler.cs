using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class CreateCityHandler : IRequestHandler<CreateCityCommand, CityModel>
{
    private readonly ICityRepository<Guid> _repository;

    public CreateCityHandler(ICityRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<CityModel> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var exist = await _repository.GetByIdAsync(request.CityModel.Id);
        if (exist != null)
        {
            throw new CityException("The city already exists");
        }

        var city = new City()
        {
            Id = Guid.NewGuid(),
            Name = request.CityModel.Name,
            CountryId = request.CountryId
        };
        
        
        await _repository.AddAsync(city);
        await _repository.SaveChangesAsync();
        return new CityModel()
        {
            Id = city.Id,
            Name = city.Name,
            CountryId = city.CountryId
        };
    }
}