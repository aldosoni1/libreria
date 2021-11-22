using PJENL.Shared.Kernel.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Libreria : IAgregateRoot
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public IEnumerable<LibreriaLibro> Libros { get; set; }
    }
}
