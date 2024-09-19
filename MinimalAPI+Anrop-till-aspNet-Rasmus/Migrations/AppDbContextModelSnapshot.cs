﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Data;

#nullable disable

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinimalAPI_Anrop_till_aspNet_Rasmus.Models.Books", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Publiced")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "J.K. Rowling",
                            Available = true,
                            Description = "Pojke med magiska krafter.",
                            Genre = "Fantasy",
                            Publiced = 1999,
                            Title = "Harry Potter"
                        },
                        new
                        {
                            ID = 2,
                            Author = "J.R.R. Tolkien",
                            Available = true,
                            Description = "En ung hobbit ger sig ut på en farofylld resa för att förstöra en kraftfull ring.",
                            Genre = "Fantasy",
                            Publiced = 1954,
                            Title = "Sagan om Ringen"
                        },
                        new
                        {
                            ID = 3,
                            Author = "Suzanne Collins",
                            Available = true,
                            Description = "En ung flicka tvingas delta i ett dödligt spel i en dystopisk framtid.",
                            Genre = "Science Fiction",
                            Publiced = 2008,
                            Title = "Hungerspelen"
                        },
                        new
                        {
                            ID = 4,
                            Author = "Dan Brown",
                            Available = false,
                            Description = "En symbolforskare avslöjar en religiös konspiration.",
                            Genre = "Thriller",
                            Publiced = 2003,
                            Title = "Da Vinci-koden"
                        },
                        new
                        {
                            ID = 5,
                            Author = "George Orwell",
                            Available = true,
                            Description = "En man kämpar mot en totalitär regim i ett övervakat samhälle.",
                            Genre = "Dystopi",
                            Publiced = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            ID = 6,
                            Author = "Jane Austen",
                            Available = true,
                            Description = "En ung kvinna navigerar genom kärlek och klass i 1800-talets England.",
                            Genre = "Romantik",
                            Publiced = 1813,
                            Title = "Stolthet och fördom"
                        },
                        new
                        {
                            ID = 7,
                            Author = "Stieg Larsson",
                            Available = false,
                            Description = "En journalist och en hacker utreder en gammal försvinnande.",
                            Genre = "Kriminalroman",
                            Publiced = 2005,
                            Title = "Män som hatar kvinnor"
                        },
                        new
                        {
                            ID = 8,
                            Author = "Fjodor Dostojevskij",
                            Available = true,
                            Description = "En fattig student överväger ett moraliskt dilemma efter att ha begått ett mord.",
                            Genre = "Klassiker",
                            Publiced = 1866,
                            Title = "Brott och straff"
                        },
                        new
                        {
                            ID = 9,
                            Author = "Mary Shelley",
                            Available = false,
                            Description = "En vetenskapsman skapar ett monster som leder till tragiska konsekvenser.",
                            Genre = "Skräck",
                            Publiced = 1818,
                            Title = "Frankenstein"
                        },
                        new
                        {
                            ID = 10,
                            Author = "Antoine de Saint-Exupéry",
                            Available = true,
                            Description = "En pilot möter en pojke från en annan planet i öknen.",
                            Genre = "Barnbok",
                            Publiced = 1943,
                            Title = "Den lille prinsen"
                        },
                        new
                        {
                            ID = 11,
                            Author = "Harper Lee",
                            Available = true,
                            Description = "En ung flicka lär sig om rättvisa och fördomar i den amerikanska södern.",
                            Genre = "Drama",
                            Publiced = 1960,
                            Title = "To Kill a Mockingbird"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
