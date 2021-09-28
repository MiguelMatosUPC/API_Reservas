using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
    }
}
