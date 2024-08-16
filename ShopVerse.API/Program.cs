using Microsoft.EntityFrameworkCore;
using MyApp.Application.Mappings;
using ShopVerse.Brands;
using ShopVerse.Categories;
using ShopVerse.Demos;
using ShopVerse.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ShopVerseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDemoAppService, DemoAppService>();
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
