using Domain.Common;
using PJENL.Shared.Kernel.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Libro : Common.IEntity, IAgregateRoot
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }
        public IEnumerable<LibreriaLibro> Librerias { get; set; }
    }
}
