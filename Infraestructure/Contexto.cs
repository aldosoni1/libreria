using Domain.Models;
using Infraestructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PJENL.Shared.Kernel.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class Contexto : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LibreriaConfiguration());
            modelBuilder.ApplyConfiguration(new LibreriaLibroConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            InterceptorTracker();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            InterceptorTracker();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            InterceptorTracker();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            InterceptorTracker();
            return base.SaveChangesAsync(cancellationToken);
        }
        public void InterceptorTracker()
        {
            IEnumerable<EntityEntry> listaCambios = ChangeTracker.Entries().Where(x => x.Entity is IEstaEliminado && x.Entity is IBitacora);
            foreach (EntityEntry entry in listaCambios)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Eliminado"] = false;
                        entry.CurrentValues["FechaCreacion"] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["FechaModificacion"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Eliminado"] = true;
                        entry.CurrentValues["FechaEliminacion"] = DateTime.Now;
                        break;
                }
            }
            //IEnumerable<EntityEntry> listaCambiosBitacoraJson = ChangeTracker.Entries().Where(x => x.Entity is IBitacoraJson);
            //if(listaCambiosBitacoraJson.Count() > 0)
            //{
            //    foreach(EntityEntry entry in listaCambiosBitacoraJson)
            //    {
            //        switch (entry.State)
            //        {
            //            case EntityState.Added:
            //                var list = new List<SeguidorCambios>();
            //                break;
            //        }
            //    }
            //}
        }
    }
}
