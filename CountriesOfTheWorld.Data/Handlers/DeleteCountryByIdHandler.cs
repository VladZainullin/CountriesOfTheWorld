using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class DeleteCountryByIdHandler : IRequestHandler<DeleteCountryByIdCommand, bool>
{
    private readonly ICountryRepository<Guid> _repository;

    public DeleteCountryByIdHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var country = await _repository.GetByIdAsync(request.Id, false);
        if (country is not null)
        {
            _repository.Delete(country);
            await _repository.SaveChangesAsync();
        }
        return true;
    }
}