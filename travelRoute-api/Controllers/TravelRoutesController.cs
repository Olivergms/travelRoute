using Domain.Dtos;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace travelRoute_api.Controllers
{
    [ApiController]
    [Route("api/travelroute")]
    public class TravelRoutesController : ControllerBase
    {
        private readonly ITravelRouteService _routeService;

        public TravelRoutesController(ITravelRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("travel")]
        public async Task<ActionResult<ResponseGetTravelDto>> SearchTravel([FromQuery]RequestTravelDto dto)
        {
            try
            {
                return Ok(await _routeService.GetTravel(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #region GetAll
        /// <summary>
        /// Get Travel Route List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<IEnumerable<TravelRoute>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TravelRoute>>> GetAll()
        {
            try
            {
                return Ok(await _routeService.FindAllAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Get Travel route by id
        /// </summary>
        /// <returns></returns>
        /// [HttpGet]
        [ProducesResponseType<TravelRoute>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelRoute>> FindById([FromRoute] int id)
        {
            try
            {
                var route = await _routeService.FindByIdAsync(id);
                return Ok(route);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Create new Travel Route
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]RequestInsertTravelRouteDto dto)
        {
            try
            {
                await _routeService.InsertAsync(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// update an existing travel route
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]TravelRoute route, [FromRoute]int id)
        {
            try
            {
                await _routeService.UpdateAsync(id, route);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }

        }

        /// <summary>
        /// Delete an existing travel route
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _routeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
