using Domain.Common;
using PJENL.Shared.Kernel.Bitacora;
using PJENL.Shared.Kernel.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Libro : Common.IEntity, IAgregateRoot, IEstaEliminado, IBitacora
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }
        public IEnumerable<LibreriaLibro> Librerias { get; set; }
        public bool Eliminado { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public Guid? UsuarioElimino { get; set; }
        public Guid UsuarioRegistro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? UsuarioModifico { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
