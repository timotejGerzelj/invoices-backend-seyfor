using InvoiceApiProject.Data;
using InvoiceApiProject.Interfaces;
using InvoiceApiProject.Models;
using Microsoft.EntityFrameworkCore;


namespace InvoiceApiProject.Repositories
{
public class InvoiceRepository : IInvoiceRepository
{
    private readonly DataContext _context;

    public InvoiceRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
    {
        return await _context.Invoices
            .Include(r => r.Client)
            .Include(r => r.Organisation)
            .ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await _context.Invoices.FindAsync(id);
    }

    public async Task<bool> InvoiceExistsAsync(int id)
    {
        return await _context.Invoices.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> CreateInvoiceAsync(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        return Save();

    }

    public async Task<IEnumerable<LineItem>> GetInvoiceLineItemsAsync(int invoiceId)
    {
        var invoice = await _context.Invoices
            .Include(r => r.LineItems)
            .FirstOrDefaultAsync(r => r.Id == invoiceId);

        return invoice?.LineItems;
    }

public async Task<bool> UpdateInvoiceAsync(int id, Invoice invoice)
{
    if (id != invoice.Id) return false;

    _context.Entry(invoice).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        bool exists = await InvoiceExistsAsync(id);
        if (!exists)
        {
            return false;
        }
        else
        {
            throw;
        }
    }

    return true;
}
public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

}
}
