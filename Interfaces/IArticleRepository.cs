using InvoiceApiProject.Models;

namespace InvoiceApiProject.Interfaces
{
public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetArticlesAsync();
    Task<bool> ArticleExistsAsync(int id);
}

}