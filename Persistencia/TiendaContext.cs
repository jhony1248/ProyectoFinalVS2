using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using System;

namespace Persistencia
{
    public class TiendaContext : DbContext
    {
        // Clases tipo entidad 
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Local> locals { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<NotCredito> notCreditos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<TipoPago> tipoPagos { get; set; }
        public DbSet<Configuracion> configuracion { get; set; }

        // Constructor vacio
        public TiendaContext() : base()
        {

        }

        // Constructor para pasar la conexión al padre
        public TiendaContext(DbContextOptions<TiendaContext> opciones)
            : base(opciones)
        {

        }
        // Se mantiene para la creación de la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                TiendaConfig.ContextOptions(optionsBuilder);
            }
        }

        // Configuración del modelo de objetos tipo entidad
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion                

            // Relación uno a muchos; un Cliente tiene muchas Facturas 
            modelBuilder.Entity<Factura>()
                .HasOne(fact => fact.Cliente)
                .WithMany(cli => cli.Facturas)
                .HasForeignKey(fact => fact.ClienteId);

            // Relación uno a muchos; un Local a una Factura
            modelBuilder.Entity<Factura>()
                .HasOne(fact => fact.Local)
                .WithMany(loc => loc.Facturas)
                .HasForeignKey(fact => fact.LocalId);

            // Relación uno a muchos; en un TipoPago se registran en varias Facturas
            modelBuilder.Entity<Factura>()
                .HasOne(fact => fact.TipoPago)
                .WithMany(tip => tip.Facturas)
                .HasForeignKey(fact => fact.TipoPagoId);

            // Relación de uno a muchos: Productos a Factura
            modelBuilder.Entity<Factura>()
                .HasOne(fact => fact.Producto)
                .WithMany(pro => pro.Facturas)
                .HasForeignKey(fact => fact.ProductoId);

            // Relación de uno a muchos: Marca con Producto
            modelBuilder.Entity<Producto>()
                .HasOne(pro => pro.Marca)
                .WithMany(mar => mar.Productos)
                .HasForeignKey(pro => pro.MarcaId);

            // Relación uno a muchos; una Factura tiene varias Notas de credito
            modelBuilder.Entity<NotCredito>()
                .HasOne(notc => notc.Factura)
                .WithMany(fact => fact.NotCreditos)
                .HasForeignKey(notc => notc.FacturaId);

        }
    }
}
