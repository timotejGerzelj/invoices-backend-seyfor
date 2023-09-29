using InvoiceApiProject.Models;

namespace InvoiceApiProject.Interfaces
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<Organisation>> GetOrganisations();
        bool OrganisationExists(int id);
        bool Save();
    }
}