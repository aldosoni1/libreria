using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Exceptions
{
    public enum CodigosRespuestaLibreria
    {
        /// <summary>
        /// Se utiliza cuando la petición se realizo correctamente.
        /// Se proceso correctamente la petición
        /// </summary>
        [Description("Se proceso correctamente la petición")]
        Succes_01 = 1,
        /// <summary>
        /// Se utiliza cuando se elimina un libro.
        /// Se elimino un libro con el id: {0}
        /// </summary>
        [Description("Se elimino un libro con el id: {0}")]
        Succes_02 = 2,
        /// <summary>
        /// Mensaje de error prueba
        /// </summary>
        [Description("Mensaje de error prueba")]
        Error_500 = 500
    }
}
