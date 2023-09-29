using InvoiceApiProject.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InvoiceApiProject.Models;
using InvoiceApiProject.Data;

namespace InvoiceApiProject.Repositories
{
    public class OrganisationRepository : IOrganisationRepository // Implement the interface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrganisationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            return await _context.Organisations.ToListAsync();
        }

        public bool OrganisationExists(int id)
        {
            return _context.Organisations.Any(o => o.Id == id);
        }

        public bool Save()
        {
            // Implement your save logic here
            return true; // Return a boolean indicating success or failure
        }
    }
}