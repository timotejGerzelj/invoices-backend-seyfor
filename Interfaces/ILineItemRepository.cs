using InvoiceApiProject.Models;

namespace InvoiceApiProject.Interfaces
{
public interface ILineItemRepository
{
    Task<IEnumerable<LineItem>> GetLineItemsAsync();
    Task<LineItem> GetLineItemByIdAsync(int id);
    Task<bool> LineItemExistsAsync(int id);
    Task<bool> CreateLineItemAsync(LineItem lineItem);
    Task<bool> UpdateLineItemAsync(LineItem lineItem);
    Task<bool> CreateMultipleLineItemsAsync(IEnumerable<LineItem> lineItems);
}

}