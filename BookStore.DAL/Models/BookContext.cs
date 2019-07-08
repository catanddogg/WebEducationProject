using BookStore.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DAL.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Avtor> Avtors { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 };
            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(new { Id = 1, Name = "test", Image = script });
                b.HasData(new { Id = 2, Name = "test" , Image = script });
                b.HasData(new { Id = 3, Name = "test", Image = script });
                b.HasData(new { Id = 4, Name = "test", Image = script });
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasData(new { Id = 1, BookId = 1, CategoryType = CategoryType.ActionAndAdventure });
                b.HasData(new { Id = 2, BookId = 2, CategoryType = CategoryType.Classic });
                b.HasData(new { Id = 3, BookId = 3, CategoryType = CategoryType.Drama });
                b.HasData(new { Id = 4, BookId = 4, CategoryType = CategoryType.Essay });
            });

            modelBuilder.Entity<Avtor>(b =>
            {
                b.HasData(new { Id = 1, BookId = 1, NameAvtor = "test", Publisher = "test2"});
                b.HasData(new { Id = 2, BookId = 2, NameAvtor = "test", Publisher = "test2"});
                b.HasData(new { Id = 3, BookId = 3, NameAvtor = "test", Publisher = "test2"});
                b.HasData(new { Id = 4, BookId = 4, NameAvtor = "test", Publisher = "test2"});
            });

            modelBuilder.Entity<Person>(b =>
            {
                b.HasData(new { Id = 1, Password = "12345", Login = "TestUser1", Role = "user", FirstName = "user1", SecondName = "user2", Age = 18});
                b.HasData(new { Id = 2, Password = "1234", Login = "TestUser3", Role = "user", FirstName = "user3", SecondName = "user4", Age = 27 });
                b.HasData(new { Id = 3, Password = "123456", Login = "TestUser2", Role = "admin", FirstName = "user5", SecondName = "user6", Age = 36 });
            });

            DateTime dateTime = DateTime.Now;
            modelBuilder.Entity<Comment>(b => 
            {
                b.HasData(new { Id = 1, UserName = "user1", Message = "Hello", createTime = dateTime });
            });

            base.OnModelCreating(modelBuilder);
        }
    } 
}