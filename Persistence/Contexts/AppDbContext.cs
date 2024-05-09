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

            builder.Entity<EventIdea>().ToTable("EventIdeas");
            builder.Entity<EventIdea>().HasKey(e => e.Id);
            builder.Entity<EventIdea>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EventIdea>()
                .HasMany(e => e.Tasks)
                .WithOne(t => t.eventIdea)
                .HasForeignKey(t => t.eventIdeaId);

            builder.Entity<EventIdea>().HasData
            (
                new EventIdea { Id = 100, Name = "Fast and Furious Movie Night", Description="Lowkey chill vibes, have guests bring snacks." }, // Id set manually due to in-memory provider
                new EventIdea { Id = 101, Name = "Game Night", Description="Play Warioware: Move It! with friends." }
            );

            builder.Entity<Task>().ToTable("Tasks");
            builder.Entity<Task>().HasKey(t => t.Id);
            builder.Entity<Task>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
                
         }
    }
}