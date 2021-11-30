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
    [Route("api/InvoicePersonal")]
    public class InvoicePersonalController : Controller
    {
        private readonly InvoicePersonalService invoicePersonalService;
        public InvoicePersonalController(InvoicePersonalService invoicePersonalService)
        {
            this.invoicePersonalService = invoicePersonalService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> AddInvoicePersonal(InvoicePersonalDTO invoicePersonal)
        {
            return Ok(await invoicePersonalService.AddAsync(invoicePersonal));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoicePersonal()
        {
            return Ok(await invoicePersonalService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoicePersonalById( int id)
        {
            return Ok(await invoicePersonalService.GetAsyncById(id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoicePersonal(int id)
        {
            await invoicePersonalService.DeleteAsync(id);
            return Ok();
        }
    }
}
