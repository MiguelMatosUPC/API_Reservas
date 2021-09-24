using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity
{
    public class PacienteRequest
    {
        public int Accion { get; set; }
        public PacienteDTO paciente { get; set; }
    }
}
