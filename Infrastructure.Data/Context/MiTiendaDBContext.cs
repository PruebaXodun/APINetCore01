using Domain.Entities.MiTienda;
using Infrastructure.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Context.MiTienda
{
    public partial class MiTiendaDbContext : DbContext, IQueryableUnitOfWork
    {
        //public MiTiendaDbContext()
        //{
        //}

        public MiTiendaDbContext(DbContextOptions<MiTiendaDbContext> options)
            : base(options)
        {
        }

        #region IDbSet Members
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleDeCompra> DetalleDeCompra { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
        #endregion IDbSet Members

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-P3TICTO;Database=MiTienda;User ID=miuser; Password=1234");
        //    }
        //}

        #region IQueryableUnitOfWork Members

        public DbSet<TEntity> CreateSet<TEntity>()
          where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });
                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        //XENDOR SP
        //public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        //{
        //    return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        //}

        //IEnumerable<TEntity> ISql.ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        //{
        //    return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        //}

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion IQueryableUnitOfWork Members

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contrasenya)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DetalleDeCompra>(entity =>
            {
                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.DetalleDeCompra)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleDeCompra_Articulo");

                entity.HasOne(d => d.OrdenDeCompra)
                    .WithMany(p => p.DetalleDeCompra)
                    .HasForeignKey(d => d.OrdenDeCompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleDeCompra_OrdenDeCompra");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrdenDeCompra>(entity =>
            {
                entity.Property(e => e.Comentario).HasMaxLength(500);

                entity.Property(e => e.FechaEntregaEstimada).HasColumnType("date");

                entity.Property(e => e.FechaGeneracion).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenDeCompra_Cliente");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenDeCompra_Empleado");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.OrdenDeCompra)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenDeCompra_Estado");
            });
        }
    }
}