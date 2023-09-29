using AutoMapper;
using InvoiceApiProject.Data;
using InvoiceApiProject.DTOs;
using InvoiceApiProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApiProject.Repositories
{
public class ClientRepository : IClientRepository
{
    private readonly DataContext _context;

    public ClientRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }


    public async Task<bool> ClientExistsAsync(int id)
    {
        return await _context.Clients.AnyAsync(e => e.Id == id);
    }

}
}