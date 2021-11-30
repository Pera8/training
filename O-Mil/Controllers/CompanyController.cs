using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using O_Mil.Helper;
using Repository.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O_Mil.Controllers
{
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private readonly CompanyService companyService;
        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }

        [Authorize(RoleEnum.Admin,RoleEnum.User)]
        [HttpPost]
        public async Task<ActionResult> AddCompany(Company company)
        {
            return Ok(await companyService.AddAsync(company));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCompany()
        {
            return Ok(await companyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompanyById(int id)
        {
            return Ok(await companyService.GetAsyncById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            await companyService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("FilterCompany")]
        public async Task<ActionResult> FilterCompany(string filter)
        {
            return Ok(await companyService.FilterCompany(filter));
        }

    }
}
