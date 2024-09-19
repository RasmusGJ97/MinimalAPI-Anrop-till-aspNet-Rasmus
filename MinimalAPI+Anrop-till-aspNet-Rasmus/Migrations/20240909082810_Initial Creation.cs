using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Publiced = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Available", "Description", "Genre", "Publiced", "Title" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling", true, "Pojke med magiska krafter.", "Fantasy", 1999, "Harry Potter" },
                    { 2, "J.R.R. Tolkien", true, "En ung hobbit ger sig ut på en farofylld resa för att förstöra en kraftfull ring.", "Fantasy", 1954, "Sagan om Ringen" },
                    { 3, "Suzanne Collins", true, "En ung flicka tvingas delta i ett dödligt spel i en dystopisk framtid.", "Science Fiction", 2008, "Hungerspelen" },
                    { 4, "Dan Brown", false, "En symbolforskare avslöjar en religiös konspiration.", "Thriller", 2003, "Da Vinci-koden" },
                    { 5, "George Orwell", true, "En man kämpar mot en totalitär regim i ett övervakat samhälle.", "Dystopi", 1949, "1984" },
                    { 6, "Jane Austen", true, "En ung kvinna navigerar genom kärlek och klass i 1800-talets England.", "Romantik", 1813, "Stolthet och fördom" },
                    { 7, "Stieg Larsson", false, "En journalist och en hacker utreder en gammal försvinnande.", "Kriminalroman", 2005, "Män som hatar kvinnor" },
                    { 8, "Fjodor Dostojevskij", true, "En fattig student överväger ett moraliskt dilemma efter att ha begått ett mord.", "Klassiker", 1866, "Brott och straff" },
                    { 9, "Mary Shelley", false, "En vetenskapsman skapar ett monster som leder till tragiska konsekvenser.", "Skräck", 1818, "Frankenstein" },
                    { 10, "Antoine de Saint-Exupéry", true, "En pilot möter en pojke från en annan planet i öknen.", "Barnbok", 1943, "Den lille prinsen" },
                    { 11, "Harper Lee", true, "En ung flicka lär sig om rättvisa och fördomar i den amerikanska södern.", "Drama", 1960, "To Kill a Mockingbird" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
