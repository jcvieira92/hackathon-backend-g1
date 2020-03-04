using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using hackathon_backdotnet_g1.Maps;

namespace hackathon_backdotnet_g1.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ApplyMigrations(this);
        }

        public void ApplyMigrations(DatabaseContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Book>();

        }

        public List<User> getUsers() => Users.OrderBy(x => x.UserId).ToList<User>();

        public User getUser(long Id) => Users.Where(x => x.UserId == Id).First();

        public void AddUser(User user)
        {
            user.CreationDate = DateTime.Parse(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            Users.Add(user);
            this.SaveChanges();
        }

        public void DeleteUser(long Id)
        {
            Users.Remove(Users.Where(x => x.UserId == Id).First());
            this.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            Users.Update(user);
            this.SaveChanges();
        }

        public List<Book> getBooks() => Books.ToList<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
            this.SaveChanges();
            return;
        }
    }
}