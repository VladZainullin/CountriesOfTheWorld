using CountriesOfTheWorld.Core.Entities;
using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CountriesOfTheWorld.Controllers;

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
    public async Task<ActionResult<IEnumerable<CountryModel>>> Get(bool includeCities = true)
    {
        try
        {
            var query = new GetAllCountriesQuery(includeCities);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
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
        catch (ArgumentNullException)
        {
            return BadRequest("Country already exists");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
        }
    }

    [HttpPut("{Id:guid}")]
    public async Task<ActionResult<CountryModel>> Put(Guid id, [FromBody] CountryModel model)
    {
        try
        {
            var query = new UpdateCountryCommand(model, id);
            var result = await _mediator.Send(query);
            if (result is null)
            {
                return BadRequest("Country not found");
            }

            return result;
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Post(Guid id, bool includeCities = true)
    {
        try
        {
            var query = new DeleteCountryByIdCommand(id);
            await _mediator.Send(query);
            return Ok("Country has been deleted");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
        }
    }
    
    [HttpDelete("{name}")]
    public async Task<ActionResult> Post(string name, bool includeCities = true)
    {
        try
        {
            var query = new DeleteCountryByNameCommand(name);
            await _mediator.Send(query);
            return Ok("Country has been deleted");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
        }
    }

    #endregion
}