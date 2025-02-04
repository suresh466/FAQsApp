﻿// <auto-generated />
using FAQsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FAQsApp.Migrations
{
    [DbContext(typeof(FaqContext))]
    partial class FaqContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FAQsApp.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "general",
                            Name = "General"
                        },
                        new
                        {
                            CategoryId = "maintenance",
                            Name = "Maintenance"
                        },
                        new
                        {
                            CategoryId = "history",
                            Name = "History"
                        });
                });

            modelBuilder.Entity("FAQsApp.Models.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TopicId");

                    b.ToTable("Faqs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "They are very intelligent..",
                            CategoryId = "general",
                            Question = "How intelligent are Retrievers?",
                            TopicId = "retriever"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Regular grooming and vet check-ups are essential...",
                            CategoryId = "maintenance",
                            Question = "How do I maintain my Retriever?",
                            TopicId = "retriever"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "Retrievers were originally bred as hunting dogs...",
                            CategoryId = "history",
                            Question = "What is the history of the Retriever breed?",
                            TopicId = "retriever"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Chihuahuas typically weigh between 2-6 pounds...",
                            CategoryId = "general",
                            Question = "How big do Chihuahuas get?",
                            TopicId = "chihuahua"
                        },
                        new
                        {
                            Id = 5,
                            Answer = "Adult Chihuahuas should be fed 2-3 times a day...",
                            CategoryId = "maintenance",
                            Question = "How often should I feed my Chihuahua?",
                            TopicId = "chihuahua"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "Chihuahuas are believed to have originated in Mexico...",
                            CategoryId = "history",
                            Question = "What is the origin of the Chihuahua breed?",
                            TopicId = "chihuahua"
                        },
                        new
                        {
                            Id = 7,
                            Answer = "Pomeranians can be good with kids if socialized early...",
                            CategoryId = "general",
                            Question = "Are Pomeranians good with kids?",
                            TopicId = "pomeranian"
                        },
                        new
                        {
                            Id = 8,
                            Answer = "Regular brushing and occasional baths are recommended...",
                            CategoryId = "maintenance",
                            Question = "How do I groom my Pomeranian?",
                            TopicId = "pomeranian"
                        },
                        new
                        {
                            Id = 9,
                            Answer = "Pomeranians are descended from large sled dogs...",
                            CategoryId = "history",
                            Question = "What is the history of the Pomeranian breed?",
                            TopicId = "pomeranian"
                        });
                });

            modelBuilder.Entity("FAQsApp.Models.Topic", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicId = "retriever",
                            Name = "Retriever"
                        },
                        new
                        {
                            TopicId = "chihuahua",
                            Name = "Chihuahua"
                        },
                        new
                        {
                            TopicId = "pomeranian",
                            Name = "Pomeranian"
                        });
                });

            modelBuilder.Entity("FAQsApp.Models.Faq", b =>
                {
                    b.HasOne("FAQsApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("FAQsApp.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
