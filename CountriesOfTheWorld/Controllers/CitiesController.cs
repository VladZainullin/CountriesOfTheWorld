using CountriesOfTheWorld.Core.Models;
using CountriesOfTheWorld.Data.Commands;
using CountriesOfTheWorld.Data.Exceptions;
using CountriesOfTheWorld.Data.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CountriesOfTheWorld.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/countries/{countryId:guid}/[controller]")]
public class CitiesController : ControllerBase
{
    #region Fields

    private readonly IMediator _mediator;

    #endregion

    #region Ctors

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityModel>>> GetAllCitiesByCountyId(Guid countryId)
    {
        try
        {
            var query = new GetAllCitiesByCountryIdQuery(countryId);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CityException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("{cityId:guid}")]
    public async Task<ActionResult<CityModel>> GetCityByCountryIdAndCityId(Guid countryId, Guid cityId)
    {
        try
        {
            var query = new GetCityByCountryIdAndCityIdQuery(countryId, cityId);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CityException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CityModel>> CreateNewCity(Guid countryId, [FromBody] CityModel model)
    {
        try
        {
            var query = new CreateCityCommand(countryId, model);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CityException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{cityId:guid}")]
    public async Task<ActionResult<CityModel>> UpdateCity(Guid countryId, Guid cityId, [FromBody] CityModel model)
    {
        try
        {
            var query = new UpdateCityByCountryIdCommand(countryId, cityId, model);
            var result = await _mediator.Send(query);
            return result;
        }
        catch (CountryException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{cityId:guid}")]
    public async Task<ActionResult> DeleteCity(Guid countryId, Guid cityId)
    {
        try
        {
            var query = new DeleteCityByCountryIdCommand(cityId);
            await _mediator.Send(query);
            return Ok("City has been deleted");
        }
        catch (CityException e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion
}