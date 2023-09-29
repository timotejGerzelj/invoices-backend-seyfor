using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApiProject.Data;
using AutoMapper;
using InvoiceApiProject.DTOs;
using InvoiceApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApiProject.Interfaces;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; // Inject IMapper
        private readonly IInvoiceRepository _invoiceRepository; // Inject Invoice repository

        public InvoiceController(DataContext context, IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _context = context;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        // GET: api/Invoice
        [HttpGet]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceDto>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices()
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }

            var invoices = await _invoiceRepository.GetInvoicesAsync();
            var invoiceDtos = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            return Ok(invoiceDtos);
        }

        // GET: api/Invoice/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(InvoiceDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return Ok(invoiceDto);
        }

        // PUT: api/Invoice/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutInvoice(int id, InvoiceDto invoiceDto)
        {
            if (id != invoiceDto.Id)
            {
                return BadRequest();
            }

            var invoice = _mapper.Map<Invoice>(invoiceDto);

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _invoiceRepository.InvoiceExistsAsync(id))
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

        // POST: api/Invoice
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(InvoiceDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<InvoiceDto>> PostInvoice(InvoiceDto invoiceDto)
        {
            if (_context.Invoices == null)
            {
                return Problem("Entity set 'AppContext.Invoices' is null.");
            }

            var invoice = _mapper.Map<Invoice>(invoiceDto);

            try
            {
                await _invoiceRepository.CreateInvoiceAsync(invoice);

                var createdInvoiceDto = _mapper.Map<InvoiceDto>(invoice);

                return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoiceDto.Id }, createdInvoiceDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during Invoice insertion: {ex}");
                return Problem("An error occurred while processing your request.", statusCode: 500);
            }
        }

        // GET: api/Invoice/5/InvoiceVrstica
        [HttpGet("{id}/InvoiceVrstica")]
        [ProducesResponseType(200, Type = typeof(InvoiceDto[]))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<LineItemDto[]>>> GetInvoiceLineItemById(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(r => r.LineItems)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            var lineItems = invoice.LineItems;
            var lineItemDtos = _mapper.Map<IEnumerable<LineItemDto>>(lineItems);

            return Ok(lineItemDtos);
        }

        [HttpGet("{id}/LineItem")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetRacunLineItemById(int id)
        {
            var lineItems = await _invoiceRepository.GetInvoiceLineItemsAsync(id);

            if (lineItems == null)
            {
                return NotFound();
            }

            return Ok(lineItems);
        }


    }
}
