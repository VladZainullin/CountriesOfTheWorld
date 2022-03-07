using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Services;
using MediatR;

namespace CountriesOfTheWorld.Data.Handlers;

public class DeleteCountryByNameHandler : IRequestHandler<DeleteCountryByNameCommand, bool>
{
    private readonly ICountryRepository<Guid> _repository;

    public DeleteCountryByNameHandler(ICountryRepository<Guid> repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(DeleteCountryByNameCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByNameAsync(request.Name, false);

        if (country != null) _repository.Delete(country);
        await _repository.SaveChangesAsync();
        return true;
    }
}