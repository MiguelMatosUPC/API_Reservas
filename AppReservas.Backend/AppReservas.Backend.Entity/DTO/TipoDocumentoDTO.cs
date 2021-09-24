using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity
{
    public class TipoDocumentoDTO
    {
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
