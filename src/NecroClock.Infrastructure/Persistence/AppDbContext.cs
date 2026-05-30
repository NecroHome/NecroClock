using Microsoft.EntityFrameworkCore;
using NecroClock.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<UserModel> Usuarios { get; set; }
    }
}
