using Microsoft.EntityFrameworkCore;
using TaskEvidence.Data;
using TaskEvidence.Models;

namespace TaskEvidence.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly EvidenceDbContext _context;

        public CompanyService(EvidenceDbContext context)
        {
            _context = context;
        }
        public async Task<List<CompanyModel>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }
    }
}
