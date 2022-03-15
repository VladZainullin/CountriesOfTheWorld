using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class UpdateCountryByIdHandler : IRequestHandler<UpdateCountryByIdCommand, CountryModel>
{
    private readonly ICountryRepository<Guid> _repository;

    public UpdateCountryByIdHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<CountryModel> Handle(UpdateCountryByIdCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        if (await _repository.GetByIdAsync(request.Id,false) == null)
        {
            throw new CountryException("Country not found");
        }
        
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