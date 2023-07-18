using System.Text.Json.Serialization;
using DbRepository;
using DbRepository.Repositories;
using DbRepository.Repositories.Interfaces;
using TestAssignment.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddMvc()
    .AddJsonOptions(o => {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
services.AddSwaggerGen();
services.AddControllers();
services.AddEndpointsApiExplorer();

services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
services.AddScoped<ICityRepository, CityRepository>();
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<INoteRepository, NoteRepository>();
services.AddScoped<IOrdersRepository, OrderRepository>();
services.AddScoped<IGeneralRepository, GeneralRepository>();
services.AddScoped<ICompanyRepository, CompanyRepository>();

services.AddDbContext<RepositoryContext>();
// Add services to the container.
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}
app.UseSwagger();

app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
