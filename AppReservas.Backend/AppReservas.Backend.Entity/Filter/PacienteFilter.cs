using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity
{
    public class PacienteFilter
    {
        public int? IdPaciente { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
    }
}
