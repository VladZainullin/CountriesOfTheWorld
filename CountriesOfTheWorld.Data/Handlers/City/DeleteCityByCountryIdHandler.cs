using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

internal sealed class DeleteCityByCountryIdHandler : IRequestHandler<DeleteCityByCountryIdCommand, bool>
{
    private readonly ICityRepository<Guid> _repository;

    public DeleteCityByCountryIdHandler(ICityRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(DeleteCityByCountryIdCommand request, CancellationToken cancellationToken)
    {
        var city = await _repository.GetByIdAsync(request.CityId);
        if (city is null)
        {
            throw new CityException("City not found");
        }
        
        _repository.Delete(city);
        await _repository.SaveChangesAsync();

        return true;
    }
}