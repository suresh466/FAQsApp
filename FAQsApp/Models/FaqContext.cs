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

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "general", Name = "General" },
                new Category { CategoryId = "maintenance", Name = "Maintenance" },
                new Category { CategoryId = "history", Name = "History" }
            );

            // Seed data for Topics
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "retriever", Name = "Retriever" },
                new Topic { TopicId = "chihuahua", Name = "Chihuahua" },
                new Topic { TopicId = "pomeranian", Name = "Pomeranian" }
            );

            // Seed data for FAQs
            modelBuilder.Entity<Faq>().HasData(
                new { Id = 1, Question = "How intelligent are Retrievers?", Answer = "They are very intelligent..", CategoryId = "general", TopicId = "retriever" },
                new { Id = 2, Question = "How do I maintain my Retriever?", Answer = "Regular grooming and vet check-ups are essential...", CategoryId = "maintenance", TopicId = "retriever" },
                new { Id = 3, Question = "What is the history of the Retriever breed?", Answer = "Retrievers were originally bred as hunting dogs...", CategoryId = "history", TopicId = "retriever" },
                new { Id = 4, Question = "How big do Chihuahuas get?", Answer = "Chihuahuas typically weigh between 2-6 pounds...", CategoryId = "general", TopicId = "chihuahua" },
                new { Id = 5, Question = "How often should I feed my Chihuahua?", Answer = "Adult Chihuahuas should be fed 2-3 times a day...", CategoryId = "maintenance", TopicId = "chihuahua" },
                new { Id = 6, Question = "What is the origin of the Chihuahua breed?", Answer = "Chihuahuas are believed to have originated in Mexico...", CategoryId = "history", TopicId = "chihuahua" },
                new { Id = 7, Question = "Are Pomeranians good with kids?", Answer = "Pomeranians can be good with kids if socialized early...", CategoryId = "general", TopicId = "pomeranian" },
                new { Id = 8, Question = "How do I groom my Pomeranian?", Answer = "Regular brushing and occasional baths are recommended...", CategoryId = "maintenance", TopicId = "pomeranian" },
                new { Id = 9, Question = "What is the history of the Pomeranian breed?", Answer = "Pomeranians are descended from large sled dogs...", CategoryId = "history", TopicId = "pomeranian" }
            );
        }
    }
}
