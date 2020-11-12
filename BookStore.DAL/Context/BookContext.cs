using BookStore.DAL.Models.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext() { }
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryInBook> CategoryInBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorInBook> AuthorInBooks { get; set; }
        public DbSet<User> Persons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherInBook> PublisherInBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Ignore(item => item.Authors)
                .Ignore(item => item.Categories)
                .Ignore(item => item.Publishers);

            modelBuilder.Entity<Category>()
                .Ignore(item => item.Books);

            modelBuilder.Entity<Author>()
                .Ignore(item => item.Books);

            modelBuilder.Entity<Publisher>()
                .Ignore(item => item.Books);

            modelBuilder.Entity<AuthorInBook>()
                .HasKey(item => new { item.AuthorId, item.BookId });
            modelBuilder.Entity<AuthorInBook>()
                .HasOne(item => item.Author)
                .WithMany(item => item.AuthorInBooks)
                .HasForeignKey(item => item.AuthorId);
            modelBuilder.Entity<AuthorInBook>()
                .HasOne(item => item.Book)
                .WithMany(item => item.AuthorInBooks)
                .HasForeignKey(item => item.BookId);

            modelBuilder.Entity<CategoryInBook>()
                .HasKey(item => new { item.BookId, item.CategoryId });
            modelBuilder.Entity<CategoryInBook>()
                .HasOne(item => item.Book)
                .WithMany(item => item.CategoryInBooks)
                .HasForeignKey(item => item.BookId);
            modelBuilder.Entity<CategoryInBook>()
                .HasOne(item => item.Category)
                .WithMany(item => item.CategoryInBooks)
                .HasForeignKey(item => item.CategoryId);

            modelBuilder.Entity<PublisherInBook>()
                .HasKey(item => new { item.BookId, item.PublisherId });
            modelBuilder.Entity<PublisherInBook>()
                .HasOne(item => item.Book)
                .WithMany(item => item.PublisherInBooks)
                .HasForeignKey(item => item.BookId);
            modelBuilder.Entity<PublisherInBook>()
                .HasOne(item => item.Publisher)
                .WithMany(item => item.PublisherInBooks)
                .HasForeignKey(item => item.PublisherId);

            base.OnModelCreating(modelBuilder);
        }
    } 
}