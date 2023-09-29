using InvoiceApiProject.Models;
namespace InvoiceApiProject.Interfaces {
public interface IInvoiceRepository {
    Task<IEnumerable<Invoice>> GetInvoicesAsync();
    Task<Invoice> GetInvoiceByIdAsync(int id);
    Task<bool> InvoiceExistsAsync(int id);
    Task<bool> CreateInvoiceAsync(Invoice invoice);
    Task<IEnumerable<LineItem>> GetInvoiceLineItemsAsync(int invoiceId);
    Task<bool> UpdateInvoiceAsync(int id, Invoice invoice);
    }
}