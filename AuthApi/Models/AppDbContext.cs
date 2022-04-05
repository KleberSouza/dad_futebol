using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace AuthApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("75e9c81e-2565-42df-b7f6-3032ab3de882"),
                    Email = "admin@pucminas.br",
                    Role = "Administrador",
                    Password = BC.HashPassword("pucminas")
                },
                new User
                {
                    Id = new Guid("16f907e9-39d4-451c-9399-85f2d01de644"),
                    Email = "jogador@pucminas.br",
                    Role = "Jogador",
                    Password = BC.HashPassword("pucminas")
                },
                new User
                {
                    Id = new Guid("0ed9eded-1aa0-44e0-83de-e3c10aebaf83"),
                    Email = "capitao@pucminas.br",
                    Role = "Capitao",
                    Password = BC.HashPassword("pucminas")
                }
            );
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
