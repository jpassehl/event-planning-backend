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

            builder.Entity<Task>().ToTable("Tasks");
            builder.Entity<Task>().HasKey(t => t.Id);
            builder.Entity<Task>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Task>()
                .HasOne(t => t.EventIdea)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.EventIdeaId);

            builder.Entity<Task>().HasData
            (
                new Task
                {
                    Id = 1,
                    Description= "Get ingredients to make salsa",
                    Done = false,
                    EventIdeaId =1

                },
                new Task
                {
                    Id = 2,
                    Description= "Charge switch controllers",
                    Done = true,
                    EventIdeaId =2
                }
            );  

            builder.Entity<EventIdea>().ToTable("EventIdeas");
            builder.Entity<EventIdea>().HasKey(e => e.Id);
            builder.Entity<EventIdea>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EventIdea>()
                .HasMany(e => e.Tasks)
                .WithOne(t => t.EventIdea)
                .HasForeignKey(t => t.EventIdeaId);

            builder.Entity<EventIdea>().HasData
            (
                new EventIdea { Id = 1, Name = "Fast and Furious Movie Night", Description="Very low-key chill vibes, have guests bring food and snacks to share, potluck style.",ImgUrl= "https://static.wikia.nocookie.net/fastandfurious/images/8/87/Fast_One_Poster.jpg" }, // Id set manually due to in-memory provider
                new EventIdea { Id = 2, Name = "Video Game Night", Description="Get together and play WarioWare: Move It! with a group of friends.", ImgUrl= "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_656/b_white/f_auto/q_auto/ncom/software/switch/70010000068678/5b072b55e8a6993071b4cde9f74d9cf7aeac0b52141177efed6c8ce9b580a435" },
                new EventIdea { Id = 3, Name = "Arts & Crafts Night", Description="Bring Your Own Lego Kit, and lets build them together while sipping on adult beverages", ImgUrl="https://pbs.twimg.com/media/EKt2HKTWoAA_Dgn?format=jpg&name=medium" }
            );
   
         }
    }
}