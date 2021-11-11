using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Libro : IEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }
        public IEnumerable<LibreriaLibro> Librerias { get; set; }
    }
}
