using Microsoft.AspNetCore.Mvc;
using InvoiceApiProject.Data;
using InvoiceApiProject.Models;
using AutoMapper;
using InvoiceApiProject.Interfaces;
using InvoiceApiProject.DTOs; 

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; // Inject IMapper
        private readonly IOrganisationRepository _organisationRepository; // Inject IOrganisationRepository

        public OrganisationController(DataContext context, IMapper mapper, IOrganisationRepository organisationRepository)
        {
            _context = context;
            _mapper = mapper;
            _organisationRepository = organisationRepository;
        }

        // GET: api/Organisation
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organisation>))]
        public async Task<ActionResult<IEnumerable<Organisation>>> GetOrganisations()
        {
            if (_context.Organisations == null)
            {
                return NotFound();
            }

            var organisations = await _organisationRepository.GetOrganisations();

            var organisationsDtos = _mapper.Map<List<OrganisationDto>>(organisations);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(organisationsDtos);
        }


    }
}
