using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Shared.Models;

namespace Login.Server
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }

        // This here is a list for all the tables that will be in the DB
        public DbSet<User> Users { get; set; }

        // Managing the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1,
                        Email = "admin@admin.com",
                        Password = "admin",
                        Name = "BAMF",
                        LuckyNumber = 69,
                        Role = 1
                    }
                );
        }
    }
}
