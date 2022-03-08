using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class UpdateCountryByNameHandler : IRequestHandler<UpdateCountryByNameCommand, CountryModel>
{
    private readonly ICountryRepository<Guid> _repository;

    public UpdateCountryByNameHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<CountryModel> Handle(UpdateCountryByNameCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var oldCountry = await _repository.GetByNameAsync(request.Name, false);
        if (oldCountry == null)
        {
            throw new CountryException("Country not found");
        }

        oldCountry.Area = request.Model.Area;
        oldCountry.Name = request.Model.Name;
        oldCountry.Cities = request.Model.Cities;
        
        _repository.Update(oldCountry);
        await _repository.SaveChangesAsync();
        
        return request.Model;
    }
}