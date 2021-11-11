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
        public async Task<IEnumerable<Libro>> GetLibros(string searchValue = null, int skip = 0, int take = 10)
        {
            var query = _context.Set<Libro>().AsQueryable();
            if (searchValue is not null)
            {
                query = query.Where(x => x.Nombre.Contains(searchValue));
            }
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task Registrar()
        {
            var listaLibros = new List<Libro>();
            for (int i = 0; i < 100; i++)
            {
                var libro = new Libro { Nombre = "Hola" + i };
                listaLibros.Add(libro);
            }
            await _context.Set<Libro>().AddRangeAsync(listaLibros);
            await _context.SaveChangesAsync();
        }
    }
}
