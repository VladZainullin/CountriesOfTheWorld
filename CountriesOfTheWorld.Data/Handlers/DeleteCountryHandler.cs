using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, bool>
{
    private readonly ICountryRepository<Guid> _repository;

    public DeleteCountryHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByIdAsync(request.Id, request.includeCities);
        if (country is not null)
        {
            _repository.Delete(country);
            await _repository.SaveChangesAsync();
        }
        return true;
    }
}