using Domain.Models;
using Domain.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly Contexto _context;
        public LibroRepository(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task Actualizar(Libro libro)
        {
            _context.Set<Libro>().Update(libro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Eliminar(Guid id)
        {
            _context.Set<Libro>().Remove(await _context.Set<Libro>().FirstOrDefaultAsync(x => x.Id.Equals(id)));
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Libro> GetById(Guid id)
        {
            return await _context.Libros.Include(x=>x.Librerias).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Libro>> GetLibros(string searchValue = null, int skip = 0, int take = 10)
        {
            var query = _context.Set<Libro>().AsQueryable();
            if (searchValue is not null)
            {
                query = query.Where(x => x.Nombre.Contains(searchValue));
            }
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Guid> Registrar(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro.Id;
        }

        public async Task<IEnumerable<Guid>> RegistrarN(IEnumerable<Libro> libros)
        {
            await _context.Libros.AddRangeAsync(libros);
            await _context.SaveChangesAsync();
            return libros.Select(x => x.Id);
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
