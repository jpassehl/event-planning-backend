using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Domain.Services;
using EventPlanningAPI.Persistence.Contexts;
using EventPlanningAPI.Services;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Configure database context
builder.Services.AddDbContext<AppDbContext>(options => {

  options.UseInMemoryDatabase("event-planning-api-in-memory");
  
});

//Add Repository
builder.Services.AddScoped<IEventIdeaRepository,EventIdeaRepository>();
// Add services to the container.
builder.Services.AddScoped<IEventIdeaService, EventIdeaService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();


app.Run();
