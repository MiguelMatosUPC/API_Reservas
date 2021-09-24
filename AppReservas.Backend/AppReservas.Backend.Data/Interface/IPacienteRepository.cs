using System;
using System.Collections.Generic;
using System.Text;
using AppReservas.Backend.Entity;

namespace AppReservas.Backend.Data
{
    public interface IPacienteRepository
    {
        int MantenerPaciente(int nAccion, PacienteDTO paciente);
        List<PacienteDTO> Listar(PacienteFilter filter);
    }
}
