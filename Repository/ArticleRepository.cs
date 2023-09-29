using InvoiceApiProject.Data;
using InvoiceApiProject.Interfaces;
using InvoiceApiProject.Models;
using Microsoft.EntityFrameworkCore;

public class ArticleRepository : IArticleRepository
{
    private readonly DataContext _context;

    public ArticleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Article>> GetArticlesAsync()
    {
    try
    {
        Console.WriteLine("DO I GET TO HERE?");
        return await _context.Articles.ToListAsync();

    }
    catch (Exception ex)
    {
        // Log the exception here
        Console.WriteLine($"Exception in GetArticlesAsync: {ex}");
        throw; // Rethrow the exception so it can be handled at a higher level if needed
    }    }

    public async Task<bool> ArticleExistsAsync(int id)
    {
        return await _context.Articles.AnyAsync(e => e.Id == id);
    }
}
