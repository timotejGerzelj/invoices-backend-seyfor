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
    public class ArticleController : ControllerBase
    {
        private readonly IMapper _mapper; // Inject IMapper
        private readonly IArticleRepository _articleRepository; // Inject Invoice repository
        private readonly DataContext _context;

        public ArticleController(
        IMapper mapper, IArticleRepository articleRepository, DataContext context)
        {
            _mapper = mapper;
            _context = context;
            _articleRepository = articleRepository;

        }

        // GET: api/Article
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ArticleDto>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles(){
            Console.WriteLine("I AM OVER HERE");

                var articles = await _articleRepository.GetArticlesAsync();
                Console.WriteLine("HI THERE?");

                var articleDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(articleDtos);
            }
    }
}