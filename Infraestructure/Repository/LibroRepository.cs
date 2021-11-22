using Domain.Models;
using Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.Data.EntityFrameworkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class LibroRepository : Repository<Libro, Guid>,ILibroRepository
    {
        private readonly Contexto _context;
        public LibroRepository(Contexto contexto):base(contexto)
        {
            _context = contexto;
        }

        public async Task<Guid> RelacionarLibroLibreria(Guid idLibro, int idLibreria)
        {
            var libreria = new LibreriaLibro { IdBook = idLibro, IdLibreria = idLibreria };
            await _context.Set<LibreriaLibro>().AddAsync(libreria);
            await _context.SaveChangesAsync();
            return libreria.Id;
        }
    }
}
