using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InvoiceApiProject.DTOs; // Import the DTO namespace
using InvoiceApiProject.Interfaces;
using InvoiceApiProject.Data;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository; // Inject Invoice repository

        public ClientController(
            DataContext context,
        IMapper mapper, IClientRepository clientRepository)
        {
            _context = context;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        // GET: api/Client
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClientDto>))]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            if (_context.LineItems == null)
            {
                return NotFound();
            }

            var clients = await _clientRepository.GetClientsAsync();

            var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clientDtos);
      }

    }
}