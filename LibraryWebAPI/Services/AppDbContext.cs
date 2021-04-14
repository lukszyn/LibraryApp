using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Reflection;

namespace LibraryWebAPI.Services
{
    public interface IAppDbContext : IDisposable
    {
        public DbSet<Book> Books { get; set; }
        DatabaseFacade Database { get; }
        int SaveChanges();
    }
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

    }
}
