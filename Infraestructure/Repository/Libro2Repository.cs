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
    public class Libro2Repository : ILibroRepository
    {
        private readonly Contexto _context;
        public Libro2Repository(Contexto contexto)
        {
            _context = contexto;
        }
        public async Task<IEnumerable<Libro>> GetLibros(string searchValue = null, int skip = 0, int take = 10)
        {
            return await _context.Set<Libro>().ToListAsync();
        }

        public Task Registrar()
        {
            throw new NotImplementedException();
        }
    }
}
