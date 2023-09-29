using InvoiceApiProject.Models;

namespace InvoiceApiProject.Interfaces
{
public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<bool> ClientExistsAsync(int id);
}

}