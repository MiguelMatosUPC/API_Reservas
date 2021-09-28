using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity.Request
{
    public class EmpleadoRequest
    {
        public int Accion { get; set; }
        public EmpleadoDTO empleado { get; set; }
    }
}
