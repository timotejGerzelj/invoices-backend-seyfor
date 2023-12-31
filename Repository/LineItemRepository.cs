using AutoMapper;
using InvoiceApiProject.Data;
using InvoiceApiProject.Interfaces;
using Microsoft.EntityFrameworkCore;

/*
    Na zacetku sem zelel LineItem kar popolnoma vezati 
    na Invoice vendar sem skozi cas opazil kako neprakticno je bilo 
*/
namespace InvoiceApiProject.Repositories
{
public class LineItemRepository : ILineItemRepository
{
    private readonly DataContext _context;

    public LineItemRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LineItem>> GetLineItemsAsync()
    {
        return await _context.LineItems.ToListAsync();
    }

    public async Task<LineItem> GetLineItemByIdAsync(int id)
    {
        return await _context.LineItems.FindAsync(id);
    }

    public async Task<bool> LineItemExistsAsync(int id)
    {
        return await _context.LineItems.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> CreateLineItemAsync(LineItem lineItem)
    {

    _context.LineItems.Add(lineItem);
    return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateLineItemAsync(LineItem lineItem)
    {
        _context.Entry(lineItem).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    // Metoda za ustvarjanje več LineItem vrstic hkrati v podatkovni bazi.
    // Uporablja se ko se ustvari popolnoma nov racun z vec vnesenimi vrsticami.
    public async Task<bool> CreateMultipleLineItemsAsync(IEnumerable<LineItem> lineItems)
    {
        _context.LineItems.AddRange(lineItems);
        return await _context.SaveChangesAsync() > 0;
    }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
}
}
