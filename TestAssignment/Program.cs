using System.Text.Json.Serialization;
using DbRepository;
using DbRepository.Repositories;
using DbRepository.Repositories.Interfaces;
using Newtonsoft.Json;
using TestAssignment.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddMvc(options => options.EnableEndpointRouting = false)
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
services.AddSwaggerGen();
services.AddEndpointsApiExplorer();
services.AddCors();

services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
services.AddScoped<ICityRepository, CityRepository>();
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<INoteRepository, NoteRepository>();
services.AddScoped<IOrdersRepository, OrderRepository>();
services.AddScoped<IGeneralRepository, GeneralRepository>();
services.AddScoped<ICompanyRepository, CompanyRepository>();

services.AddDbContext<RepositoryContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(builder=> builder.WithOrigins("http://localhost:4200", "http://localhost:4200/api/").AllowAnyHeader().AllowAnyMethod());

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "DefaultApi",
        template: "api/{controller}/{action}");
    routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
});

app.MapControllers();


app.Run();
