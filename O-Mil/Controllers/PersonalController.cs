using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O_Mil.Controllers
{
    [Route("api/Personal")]
    public class PersonalController : Controller
    {
        private readonly PersonalService personalService;

        public PersonalController(PersonalService personalService)
        {
            this.personalService = personalService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> AddPersonal(Personal personal)
        {
            return Ok(await personalService.AddAsync(personal));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPersonal()
        {
            return Ok(await personalService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPersonalById(int id)
        {
            return Ok(await personalService.GetAsyncById(id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonal(int id)
        {
            await personalService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("FilterPersonalName")]
        public async Task<ActionResult> FilterPersonalName(string filter)
        {
            return Ok(await personalService.FilterCompany(filter));
        }
    }
}
