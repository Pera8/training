using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O_Mil.Controllers
{
    [Route("api/ReductionCompany")]
    public class ReductionCompanyController : Controller
    {
        private readonly ReductionCompanyService reductionCompanyService;
        public ReductionCompanyController(ReductionCompanyService reductionCompanyService)
        {
            this.reductionCompanyService = reductionCompanyService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> AddReducationCompany(ReductionCompanyDTO reductionCompany)
        {
            return Ok(await reductionCompanyService.AddAsync(reductionCompany));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReducationCompany()
        {
            return Ok(await reductionCompanyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReductionCompanyById(int id)
        {
            return Ok( await reductionCompanyService.GetAsyncById(id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReductionComapny(int id)
        {
            await reductionCompanyService.DeleteAsync(id);
            return Ok();
        }
    }
}
