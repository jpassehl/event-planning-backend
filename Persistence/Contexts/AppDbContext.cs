using EventPlanningAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = EventPlanningAPI.Domain.Models.Task;

namespace EventPlanningAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<EventIdea> EventIdeas{get; set;}
        public DbSet<Task> Tasks {get; set;}

         protected override void OnModelCreating(ModelBuilder builder)
         {
            base.OnModelCreating(builder);

            builder.Entity<EventIdea>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.eventIdea)
                .HasForeignKey(t => t.eventIdeaId);

            builder.Entity<EventIdea>().HasData
            (
                new EventIdea { Id = 100, Name = "Fast and Furious Movie Night", Description="Lowkey chill vibes, have guests bring snacks" }, // Id set manually due to in-memory provider
                new EventIdea { Id = 101, Name = "Game Night", Description="Play Warioware Move It! With Friends" }
            );
                
         }
    }
}