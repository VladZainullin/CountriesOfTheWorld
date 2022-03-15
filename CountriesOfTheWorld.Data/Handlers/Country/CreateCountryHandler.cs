using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CountryModel>
{
    private readonly ICountryRepository<Guid> _repository;

    public CreateCountryHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<CountryModel> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var exist = await _repository.GetByNameAsync(request.Model.Name, false);
        if (exist != null)
        {
            throw new CountryException("The country with this name already exists");
        }
        
        var country = new Country()
        {
            Id = Guid.NewGuid(),
            Name = request.Model.Name,
            Area = request.Model.Area,
            Cities = new List<City>()
        };

        await _repository.AddAsync(country);
        await _repository.SaveChangesAsync();
        
        return new CountryModel()
        {
            Name = country.Name,
            Area = country.Area,
            Cities = country.Cities
        };
    }
}