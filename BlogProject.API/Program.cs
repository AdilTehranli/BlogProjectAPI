using BlogProject.Business.ExtensionServices.Implements;
using BlogProject.Business.ExtensionServices.Interfaces;
using BlogProject.Business.Services.Implements;
using BlogProject.Business.Services.Interfaces;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Implements;
using BlogProject.DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:MSSQL"]);

});
builder.Services.AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<CategoryService>();
});

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFileService, FileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
