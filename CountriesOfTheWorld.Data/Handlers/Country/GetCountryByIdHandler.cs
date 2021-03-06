using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, CountryModel>
{
    private readonly ICountryRepository<Guid> _repository;

    public GetCountryByIdHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<CountryModel> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var country = await _repository.GetByIdAsync(request.id, request.includeCities);
        if (country == null)
        {
            throw new CountryException("Country not found");
        }

        return new CountryModel()
        {
            Name = country.Name,
            Area = country.Area,
            Cities = country.Cities
        };
    }
}