using AutoMapper;
using InvoiceApiProject.DTOs; // Import your DTOs
using InvoiceApiProject.Models; // Import your models

namespace InvoiceApiProject.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap for Invoice
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();

            // CreateMap for LineItem
            CreateMap<LineItem, LineItemDto>();
            CreateMap<LineItemDto, LineItem>();

            // CreateMap for Client
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            // CreateMap for Organisation
            CreateMap<Organisation, OrganisationDto>();
            CreateMap<OrganisationDto, Organisation>();
            
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            
            // Add more CreateMap statements for other models as needed
        }
    }
}
