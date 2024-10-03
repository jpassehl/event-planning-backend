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
            builder.Entity<EventIdea>().HasKey(e => e.id);
            builder.Entity<EventIdea>().Property(e => e.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EventIdea>()
                .HasMany(e => e.tasks)
                .WithOne(t => t.eventIdea)
                .HasForeignKey(t => t.eventIdeaId);

            builder.Entity<EventIdea>().HasData
            (
                new EventIdea { id = 1, name = "Fast and Furious Movie Night", description="Very low-key chill vibes, have guests bring food and snacks to share, potluck style.",imgUrl= "https://static.wikia.nocookie.net/fastandfurious/images/8/87/Fast_One_Poster.jpg" }, // Id set manually due to in-memory provider
                new EventIdea { id = 2, name = "Video Game Night", description="Get together and play WarioWare: Move It! with a group of friends.", imgUrl= "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000068678/5b072b55e8a6993071b4cde9f74d9cf7aeac0b52141177efed6c8ce9b580a435" },
                new EventIdea { id = 3, name = "Arts & Crafts Night", description="Bring Your Own Lego Kit, and lets build them together while sipping on adult beverages", imgUrl="https://pbs.twimg.com/media/EKt2HKTWoAA_Dgn?format=jpg&name=medium" }
            );

            builder.Entity<Task>().ToTable("Tasks");
            builder.Entity<Task>().HasKey(t => t.id);
            builder.Entity<Task>().Property(t => t.id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Task>().HasData
            (
                new Task
                {
                    id = 1,
                    description= "Get ingredients to make salsa",
                    done = false,
                    eventIdeaId =1

                },
                new Task
                {
                    id = 2,
                    description= "Charge switch controllers",
                    done = true,
                    eventIdeaId =2
                }
            );     
         }
    }
}