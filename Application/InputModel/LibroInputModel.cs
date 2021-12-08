using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InputModel
{
    public class LibroInputModel
    {
        [Required]
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int CantidadHojas { get; set; }
    }
}
