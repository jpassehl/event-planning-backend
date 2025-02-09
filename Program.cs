using AutoMapper;
using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Domain.Services;
using EventPlanningAPI.Mapping;
using EventPlanningAPI.Persistence.Contexts;
using EventPlanningAPI.Services;
using Microsoft.EntityFrameworkCore;
using EventPlanningApp.API.Domain.Repositories;
using EventPlanningApp.API.Persistence.Repositories;
using EventPlanningApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Configure database context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("event-planning-api-in-memory");
});

//Add Repositories
builder.Services.AddScoped<IEventIdeaRepository, EventIdeaRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Add services to the container.
builder.Services.AddScoped<IEventIdeaService, EventIdeaService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// add controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ModelToResourceProfile());
    mc.AddProfile(new ResourceToModelProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

//guarantee that our database is going to be “created” when the application starts since we’re using an in-memory provider.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
