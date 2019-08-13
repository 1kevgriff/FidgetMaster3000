using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace FidgetPro.Fidgetmaster.Web.Controllers
{
    [Route("api/fidgets")]
    [ApiController]
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
            await _fidgetRepository.CreateOrUpdate(fidget);

            return Ok();
        }
    }
}