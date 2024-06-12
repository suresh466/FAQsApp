using Microsoft.EntityFrameworkCore;

namespace FAQsApp.Models
{
    public class FaqContext : DbContext
    {
        public FaqContext(DbContextOptions<FaqContext> options)
                : base(options)
        { }

        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "afc", Name = "AFC" },
                new Category { CategoryId = "nfc", Name = "NFC" }
            );
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "north", Name = "North" },
                new Topic { TopicId = "south", Name = "South" },
                new Topic { TopicId = "east", Name = "East" },
                new Topic { TopicId = "west", Name = "West" }
            );
            modelBuilder.Entity<Faq>().HasData(
                new { Id=1, Name = "Arizona Cardinals", Question = "Question 1?", Answer = "Answer 1!", CategoryId = "nfc", TopicId = "west" },
                new { Id=2, Name = "Atlanta Falcons", Question = "Question 2?", Answer = "Answer 2!", CategoryId = "nfc", TopicId = "south" },
                new { Id=3, Name = "Baltimore Ravens", Question = "Question 3?", Answer = "Answer 3!", CategoryId = "afc", TopicId = "north" }
            );
        }
    }
}
