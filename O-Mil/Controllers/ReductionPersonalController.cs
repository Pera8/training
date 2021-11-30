using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using O_Mil.Helper;
using Repository.Models;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O_Mil.Controllers
{
    [Route("api/ReductionPersonal")]
    public class ReductionPersonalController : Controller
    {
        private readonly ReductionPersonalService reductionPersonalService;
        public ReductionPersonalController(ReductionPersonalService reductionPersonalService)
        {
            this.reductionPersonalService = reductionPersonalService;
        }

        [HttpPost]
        public async Task<ActionResult> AddReductionPersonal(ReductionPersonalDTO reductionPersonal)
        {
            return Ok(await reductionPersonalService.AddAsync(reductionPersonal));
        }

        [Authorize(RoleEnum.User)]
        [HttpGet]
        public async Task<ActionResult> GetAllReductionPersonal()
        {
            return Ok(await reductionPersonalService.GetAllAsync());
        }
       // [Authorize(Policy = "DeleteRolePolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetReductionPersonalById(int id)
        {
            return Ok(await reductionPersonalService.GetAsyncById(id));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReductionPersonal(int id)
        {
            await reductionPersonalService.DeleteAsync(id);
            return Ok();
        }
    }
}
