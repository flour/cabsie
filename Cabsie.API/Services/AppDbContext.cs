using Cabsie.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cabsie.API.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>()
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValue(DateTime.Now);
        }
    }
}
