using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CountriesOfTheWorld.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    #region Fields

    private readonly IMediator _mediator;

    #endregion

    #region Ctors

    public CountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryModel>>> GetAllCountries(bool includeCities = true)
    {
        try
        {
            var query = new GetAllCountriesQuery(includeCities);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CountryModel>> Get(Guid id, bool includeCities = true)
    {
        try
        {
            var query = new GetCountryByIdQuery(id, includeCities);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
    } 
    
    [HttpGet("{name}")]
    public async Task<ActionResult<CountryModel>> Get(string name, bool includeCities = true)
    {
        try
        {
            var query = new GetCountryByNameQuery(name, includeCities);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
    } 
    
    [HttpPost]
    public async Task<ActionResult<CountryModel>> Post([FromBody] CountryModel model)
    {
        try
        {
            var query = new CreateCountryCommand(model);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id:guid}")]
    public async Task<ActionResult<CountryModel>> Put(Guid id, [FromBody] CountryModel model)
    {
        try
        {
            var query = new UpdateCountryByIdCommand(model, id);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{name}")]
    public async Task<ActionResult<CountryModel>> Put(string name, [FromBody] CountryModel model)
    {
        try
        {
            var query = new UpdateCountryByNameCommand(model, name);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Post(Guid id)
    {
        try
        {
            var query = new DeleteCountryByIdCommand(id);
            await _mediator.Send(query);
            return Ok("Country has been deleted");
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{name}")]
    public async Task<ActionResult> Post(string name)
    {
        try
        {
            var query = new DeleteCountryByNameCommand(name);
            await _mediator.Send(query);
            return Ok("Country has been deleted");
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion
}