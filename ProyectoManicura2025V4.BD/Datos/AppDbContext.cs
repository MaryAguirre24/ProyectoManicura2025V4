using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.BD.Datos
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<ServicioE> Servicios { get; set; }
        public DbSet<turno> Turnos { get; set; }



        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<turno>()
                .Property(t => t.Estado)
                .HasConversion<string>()
                .HasMaxLength(20);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<turno>()
                        .HasOne(t => t.Servicio)
                        .WithMany(s => s.Turnos)
                        .HasForeignKey(t => t.ServicioId)
                        .OnDelete(DeleteBehavior.Restrict);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
