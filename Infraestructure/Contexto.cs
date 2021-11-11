using Domain.Models;
using Infraestructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class Contexto : DbContext
    {
        
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
    }
}
