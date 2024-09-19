using Microsoft.EntityFrameworkCore;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        {
            
        }

        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>().HasData(
                new Books()
                {
                    ID = 1,
                    Title = "Harry Potter",
                    Author = "J.K. Rowling",
                    Publiced = 1999,
                    Genre = "Fantasy",
                    Description = "Pojke med magiska krafter.",
                    Available = true
                }, new Books()
                {
                    ID = 2,
                    Title = "Sagan om Ringen",
                    Author = "J.R.R. Tolkien",
                    Publiced = 1954,
                    Genre = "Fantasy",
                    Description = "En ung hobbit ger sig ut på en farofylld resa för att förstöra en kraftfull ring.",
                    Available = true
                },

                new Books()
                {
                    ID = 3,
                    Title = "Hungerspelen",
                    Author = "Suzanne Collins",
                    Publiced = 2008,
                    Genre = "Science Fiction",
                    Description = "En ung flicka tvingas delta i ett dödligt spel i en dystopisk framtid.",
                    Available = true
                },

                new Books()
                {
                    ID = 4,
                    Title = "Da Vinci-koden",
                    Author = "Dan Brown",
                    Publiced = 2003,
                    Genre = "Thriller",
                    Description = "En symbolforskare avslöjar en religiös konspiration.",
                    Available = false
                },

                new Books()
                {
                    ID = 5,
                    Title = "1984",
                    Author = "George Orwell",
                    Publiced = 1949,
                    Genre = "Dystopi",
                    Description = "En man kämpar mot en totalitär regim i ett övervakat samhälle.",
                    Available = true
                },

                new Books()
                {
                    ID = 6,
                    Title = "Stolthet och fördom",
                    Author = "Jane Austen",
                    Publiced = 1813,
                    Genre = "Romantik",
                    Description = "En ung kvinna navigerar genom kärlek och klass i 1800-talets England.",
                    Available = true
                },

                new Books()
                {
                    ID = 7,
                    Title = "Män som hatar kvinnor",
                    Author = "Stieg Larsson",
                    Publiced = 2005,
                    Genre = "Kriminalroman",
                    Description = "En journalist och en hacker utreder en gammal försvinnande.",
                    Available = false
                },

                new Books()
                {
                    ID = 8,
                    Title = "Brott och straff",
                    Author = "Fjodor Dostojevskij",
                    Publiced = 1866,
                    Genre = "Klassiker",
                    Description = "En fattig student överväger ett moraliskt dilemma efter att ha begått ett mord.",
                    Available = true
                },

                new Books()
                {
                    ID = 9,
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    Publiced = 1818,
                    Genre = "Skräck",
                    Description = "En vetenskapsman skapar ett monster som leder till tragiska konsekvenser.",
                    Available = false
                },

                new Books()
                {
                    ID = 10,
                    Title = "Den lille prinsen",
                    Author = "Antoine de Saint-Exupéry",
                    Publiced = 1943,
                    Genre = "Barnbok",
                    Description = "En pilot möter en pojke från en annan planet i öknen.",
                    Available = true
                },

                new Books()
                {
                    ID = 11,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Publiced = 1960,
                    Genre = "Drama",
                    Description = "En ung flicka lär sig om rättvisa och fördomar i den amerikanska södern.",
                    Available = true
                }

            );
        }

    }
}
