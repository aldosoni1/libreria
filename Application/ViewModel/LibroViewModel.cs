using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class LibroViewModel
    {
        public LibroViewModel(Guid id, string nombre, string autor, int noPaginas)
        {
            Id = id;
            Nombre = nombre;
            Autor = autor;
            NoPaginas = noPaginas;
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int NoPaginas { get; set; }
    }
}
