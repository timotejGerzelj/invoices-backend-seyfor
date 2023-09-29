using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using InvoiceApiProject.Data;
using InvoiceApiProject.Interfaces;
using InvoiceApiProject.Repositories;

using InvoiceApiProject.Helper;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Ker nisem bil siguren kaksen CORS zelite sem kar omogocil dostop
// Vsem metodam ni dobra praksa in ne bi je uporabil v pravem projektu
// vendar sem za vsak slucaj jo tako nastavil tukaj
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

// Register repositories
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<ILineItemRepository, LineItemRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework Core DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




// Register AutoMapper
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();


app.Run();
