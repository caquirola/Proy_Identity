using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proy_Identity.Models;

namespace Proy_Identity.Identity
{
    public class MyIdentityDBContext : IdentityDbContext<User, IdentityRole, string>
    {
        public MyIdentityDBContext(DbContextOptions<MyIdentityDBContext> options)
            : base(options)
        { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");
        }

    }
}