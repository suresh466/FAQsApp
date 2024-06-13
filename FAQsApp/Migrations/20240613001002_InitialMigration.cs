using Microsoft.EntityFrameworkCore.Migrations;

namespace FAQsApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    TopicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faqs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faqs_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "general", "General" },
                    { "maintenance", "Maintenance" },
                    { "history", "History" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "Name" },
                values: new object[,]
                {
                    { "retriever", "Retriever" },
                    { "chihuahua", "Chihuahua" },
                    { "pomeranian", "Pomeranian" }
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CategoryId", "Question", "TopicId" },
                values: new object[,]
                {
                    { 1, "They are very intelligent..", "general", "How intelligent are Retrievers?", "retriever" },
                    { 2, "Regular grooming and vet check-ups are essential...", "maintenance", "How do I maintain my Retriever?", "retriever" },
                    { 3, "Retrievers were originally bred as hunting dogs...", "history", "What is the history of the Retriever breed?", "retriever" },
                    { 4, "Chihuahuas typically weigh between 2-6 pounds...", "general", "How big do Chihuahuas get?", "chihuahua" },
                    { 5, "Adult Chihuahuas should be fed 2-3 times a day...", "maintenance", "How often should I feed my Chihuahua?", "chihuahua" },
                    { 6, "Chihuahuas are believed to have originated in Mexico...", "history", "What is the origin of the Chihuahua breed?", "chihuahua" },
                    { 7, "Pomeranians can be good with kids if socialized early...", "general", "Are Pomeranians good with kids?", "pomeranian" },
                    { 8, "Regular brushing and occasional baths are recommended...", "maintenance", "How do I groom my Pomeranian?", "pomeranian" },
                    { 9, "Pomeranians are descended from large sled dogs...", "history", "What is the history of the Pomeranian breed?", "pomeranian" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CategoryId",
                table: "Faqs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_TopicId",
                table: "Faqs",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
