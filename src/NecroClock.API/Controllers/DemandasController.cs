using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NecroClock.Application.Interfaces;
using NecroClock.Application.Models.DTOs;
using System.Security.Claims;

namespace NecroClock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemandasController : ControllerBase
    {
        private readonly IDemandasService _demandasService;

        public DemandasController(
            IDemandasService demandasService)
        {
            _demandasService = demandasService;
        }

        [Authorize]
        [HttpPost("AddDemanda")]
        public async Task<IActionResult> AddDemanda([FromBody] DemandaDTO dto)
        {
            string user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(user, out long userId))
            {
                return Unauthorized();
            }

            if (dto == null)
            {
                return BadRequest("Dados inválidos");
            }

            return Ok(await _demandasService.AddDemanda(dto, userId));
        }

        [Authorize]
        [HttpPut("UpdateDemanda")]
        public async Task<IActionResult> UpdateDemanda([FromBody] DemandaDTO dto)
        {
            string user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(user, out long userID))
            {
                return Unauthorized();
            }

            if (dto == null)
            {
                return BadRequest("Dados Inválidos.");
            }

            return Ok(await _demandasService.UpdateDemanda(dto, userID));
        }

        [Authorize]
        [HttpDelete("DeleteDemanda")]
        public async Task<IActionResult> DeleteDemanda(long demandaID)
        {
            string user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(user, out long userID))
            {
                return Unauthorized();
            }

            return Ok(await _demandasService.DeleteDemanda(demandaID, userID));
        }

        [Authorize]
        [HttpGet("GetDemandas")]
        public async Task<IActionResult> GetDemandas(DateTime inicio, DateTime fim)
        {
            string user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!long.TryParse(user, out long userID))
            {
                return Unauthorized();
            }

            return Ok(await _demandasService.GetDemandas(inicio, fim, userID));
        }
    }
}
