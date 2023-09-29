using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApiProject.Data;
using AutoMapper;
using InvoiceApiProject.DTOs;
using InvoiceApiProject.Interfaces;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; // Inject IMapper
        private readonly ILineItemRepository _lineItemRepository; // Inject LineItem repository

        public LineItemController(DataContext context, IMapper mapper, ILineItemRepository lineItemRepository)
        {
            _context = context;
            _mapper = mapper;
            _lineItemRepository = lineItemRepository;
        }

        // GET: api/LineItem
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LineItemDto>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<LineItemDto>>> GetLineItems()
        {
            if (_context.LineItems == null)
            {
                return NotFound();
            }

            var lineItems = await _lineItemRepository.GetLineItemsAsync();
            var lineItemDtos = _mapper.Map<IEnumerable<LineItemDto>>(lineItems);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(lineItemDtos);
        }

        // GET: api/LineItem/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(LineItemDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<LineItemDto>> GetLineItem(int id)
        {
            if (_context.LineItems == null)
            {
                return NotFound();
            }
            try {
            var lineItem = await _lineItemRepository.GetLineItemByIdAsync(id);

            if (lineItem == null)
            {
                return NotFound();
            }

            var lineItemDto = _mapper.Map<LineItemDto>(lineItem);

            return Ok(lineItemDto);
            }
            catch (Exception ex) {
                Console.WriteLine($"Exception while getting LineItem: {ex}");
                return BadRequest("An error occurred while processing your request.");
            }
        }

        // PUT: api/LineItem/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutLineItem(int id, LineItemDto lineItemDto)
        {
            if (id != lineItemDto.Id)
            {
                return BadRequest();
            }

            var lineItem = _mapper.Map<LineItem>(lineItemDto);

            _context.Entry(lineItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _lineItemRepository.LineItemExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LineItem
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<LineItemDto>> PostLineItem(LineItemDto lineItemDto)
        {
            if (_context.LineItems == null)
            {
                return Problem("Entity set 'InvoiceApiProjectContext.LineItems' is null.");
            }

            var lineItem = _mapper.Map<LineItem>(lineItemDto);

            try
            {
                await _lineItemRepository.CreateLineItemAsync(lineItem);

                // Log the inserted LineItem data
                Console.WriteLine($"Inserted LineItem: Id={lineItem.Id}, Kolicina={lineItem.Quantity}, InvoiceId={lineItem.InvoiceId}, ArtikelId={lineItem.ArticleId}");
                var createdLineItemDto = _mapper.Map<LineItemDto>(lineItem);
                return CreatedAtAction(nameof(GetLineItem), new { id = createdLineItemDto.Id }, createdLineItemDto);
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"Exception during LineItem insertion: {ex}");
                return Problem("An error occurred while processing your request.", statusCode: 500);
            }
        }

        // POST: api/LineItem/Multiple
        [HttpPost("Multiple")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostMultipleLineItem(List<LineItemDto> lineItemDtos)
        {
            if (_context.LineItems == null)
            {
                return Problem("Entity set 'InvoiceApiProjectContext.LineItems' is null.");
            }

            try
            {
                // Ensure there are items in the list
                if (lineItemDtos == null || !lineItemDtos.Any())
                {
                    return BadRequest("No LineItem items provided in the request.");
                }

                var lineItems = _mapper.Map<List<LineItem>>(lineItemDtos);
                await _lineItemRepository.CreateMultipleLineItemsAsync(lineItems);

                // Log the inserted LineItem data
                foreach (var lineItem in lineItems)
                {
                    Console.WriteLine($"Inserted LineItem: Id={lineItem.Id}, Quantity={lineItem.Quantity}, InvoiceId={lineItem.InvoiceId}, ArticleId={lineItem.ArticleId}");
                }

                var createdLineItemDtos = _mapper.Map<List<LineItemDto>>(lineItems);

                return CreatedAtAction(nameof(GetLineItem), new { id = createdLineItemDtos[0].Id }, createdLineItemDtos);
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"Exception during LineItem insertion: {ex}");
                return Problem("An error occurred while processing your request.", statusCode: 500);
            }
        }
    }
}