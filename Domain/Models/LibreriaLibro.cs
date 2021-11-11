using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class LibreriaLibro
    {
        public Guid Id { get; set; }
        public int IdLibreria { get; set; }
        public Guid IdBook { get; set; }
        public int Cantidad { get; set; }
        public Libreria Libreria { get; set; }
        public Libro Libro { get; set; }
    }
}
