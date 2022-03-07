using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, CountryModel>
{
    private readonly ICountryRepository<Guid> _repository;

    public UpdateCountryHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<CountryModel> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var country = new Country()
        {
            Id = request.Id,
            Name = request.Model.Name,
            Area = request.Model.Area,
            Cities = request.Model.Cities
        };
        
        _repository.Update(country);
        await _repository.SaveChangesAsync();
        return request.Model;
    }
}