using System.Linq;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FidgetPro.Fidgetmaster.Web.Controllers
{
    [Route("api/fidgets")]
    [ApiController]
    [Authorize]
    public class FidgetController : ControllerBase
    {
        private readonly IFidgetRepository _fidgetRepository;

        public FidgetController(IFidgetRepository fidgetRepository)
        {
            _fidgetRepository = fidgetRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetFidgets()
        {
            return Ok(await _fidgetRepository.GetFidgets());
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateOrUpdateFidget(Fidget fidget)
        {
            var claim = User?.Claims.FirstOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            var userName = claim?.Value;

            await _fidgetRepository.CreateOrUpdate(fidget, userName);

            return Ok();
        }
    }
}