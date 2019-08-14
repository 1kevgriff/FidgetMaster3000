using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FidgetPro.Fidgetmaster.Web.Controllers
{
    [Route("api/fidgetTypes")]
    [ApiController]
    [Authorize]
    public class FidgetTypeController : ControllerBase
    {
        private readonly IFidgetTypeRepository _fidgetTypeRepository;

        public FidgetTypeController(IFidgetTypeRepository fidgetTypeRepository)
        {
            _fidgetTypeRepository = fidgetTypeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetFidgetTypes()
        {
            return Ok(await _fidgetTypeRepository.GetFidgetTypes());
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateOrUpdateFidgetType(FidgetType fidgetType)
        {
            await _fidgetTypeRepository.CreateOrUpdate(fidgetType);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFidgetType(long id)
        {
            await _fidgetTypeRepository.DeleteFidgetType(id);
            return Ok();
        }
    }
}
