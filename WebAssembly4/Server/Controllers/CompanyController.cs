using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskEvidence.Models;
using TaskEvidence.Services;

namespace TaskEvidence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("getCompanies")]
        public async Task<List<CompanyModel>> GetCompaniesAsync()
        {
            var companies = await _companyService.GetCompaniesAsync();
            return companies; //Ok
        }
    }
}
