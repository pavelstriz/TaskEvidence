using TaskEvidence.Models;

namespace TaskEvidence.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyModel>> GetCompaniesAsync();
    }
}