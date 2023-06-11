using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    internal class ApplicationDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        //Fluent tbles
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Author> Fluent_Author { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Authors
            //rename tbl and col name
            modelBuilder.Entity<Fluent_Author>().ToTable("Fluent_Authors");
            modelBuilder.Entity<Fluent_Author>().Property(u => u.BirthDate).HasColumnName("DOB");


            modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(u=>u.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

            modelBuilder.Entity<Fluent_Book>().HasOne(u => u.BookDetail).WithOne(u => u.Book).HasForeignKey<Fluent_BookDetail>(u => u.BookId);
            modelBuilder.Entity<Fluent_Book>().HasOne(u => u.Publisher).WithMany(u => u.Books).HasForeignKey(u => u.Publisher_Id);




            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10,5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new {u.Author_Id,u.BookId});
            var bookList = new Book[]
                {
                    new Book {BookId=1,Title="Fake Sunday",ISBN="77652",Price=20.93m,Publisher_Id=1 },
                    new Book {BookId=2,Title="Cook jar",ISBN="76782",Price=30.12m,Publisher_Id=2 },
                };

            modelBuilder.Entity<Book>().HasData(bookList);
            modelBuilder.Entity<Book>().HasData(
                     new Book { BookId = 3, Title = "Two Road Not Taken", ISBN = "7342", Price = 20.93m ,Publisher_Id=3 },
                    new Book { BookId = 4, Title = "Sherlock Holmes", ISBN = "8542", Price = 125.12m, Publisher_Id=3 }

                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id=1,Name="Pub 1 Jimmy",Location="Chicago"},
                new Publisher { Publisher_Id = 2, Name = "Pub 2 Jimmy", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Jimmy", Location = "Singapore" }
                );
        }

        
    }
}
