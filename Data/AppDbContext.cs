using Microsoft.EntityFrameworkCore;
using ykuasoft.Models;

namespace ykuasoft.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cargos> Cargos { get; set; }  // DbSet para la entidad Cargo
        public DbSet<Usuarios> Usuarios { get; set; }  // DbSet para la entidad Usuarios
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; } 
        public DbSet<Bancos> Bancos { get; set; } 
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<Timbrado> Timbrado { get; set; }
        public DbSet<Caja> Caja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>()
                .HasKey(c => c.Id_cargo);  // Configura la propiedad Id como clave primaria

            modelBuilder.Entity<Usuarios>()
                .HasKey(u => u.Id_usuario);  // Configura la propiedad Id como clave primaria

            modelBuilder.Entity<Roles>()
               .HasKey(u => u.Id_rol);

            modelBuilder.Entity<Permisos>()
               .HasKey(u => u.Id_permiso);

            modelBuilder.Entity<Bancos>()
               .HasKey(u => u.Id_banco);

            modelBuilder.Entity<FormaPago>()
               .HasKey(u => u.Id_forma_pago);

            modelBuilder.Entity<Timbrado>()
               .HasKey(u => u.Nro_timbrado);

            modelBuilder.Entity<Caja>()
               .HasKey(u => u.Nro_caja);

            base.OnModelCreating(modelBuilder);
        }
    }
}
