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
    [Route("api/InvoiceCompany")]
    public class InvoiceCompanyController : Controller
    {
        private readonly InvoiceCompanyService invoiceCompanyService;
        public InvoiceCompanyController(InvoiceCompanyService invoiceCompanyService)
        {
            this.invoiceCompanyService = invoiceCompanyService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> AddInvoiceCompany(InvoiceCompanyDTO invoiceCompany)
        {
            return Ok(await invoiceCompanyService.AddAsyncInvoice(invoiceCompany));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceCompany()
        {
            return Ok(await invoiceCompanyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceCompanyById(int id)
        {
            return Ok(await invoiceCompanyService.GetAsyncById(id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceCompany(int id)
        {
            await invoiceCompanyService.DeleteAsync(id);
            return Ok();
        }
    }
}
