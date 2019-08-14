using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FidgetPro.Fidgetmaster.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public string AuthenticatedUserName
        {
            get
            {
                var claim = User.Claims.FirstOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                var userName = claim?.Value;
                return userName;
            }
        }

        public bool CanApproveFidgets
        {
            get {
                return User.Claims.Any(p =>
                    p.Type == ClaimTypes.Role && p.Value == "CanApproveFidgets");
            }
        }
    }

    [Route("api/fidgets")]
    [ApiController]
    [Authorize]
    public class FidgetController : BaseController
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
            if (User == null) return Unauthorized();
            await _fidgetRepository.CreateOrUpdate(fidget, AuthenticatedUserName, CanApproveFidgets);

            return Ok();
        }
    }
}