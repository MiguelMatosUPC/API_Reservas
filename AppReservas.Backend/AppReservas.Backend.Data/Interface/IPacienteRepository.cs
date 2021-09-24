using System;
using System.Collections.Generic;
using System.Text;
using AppReservas.Backend.Entity;

namespace AppReservas.Backend.Data
{
    public interface IPacienteRepository
    {
        int MantenerPaciente(PacienteRequest request);
        List<PacienteDTO> Listar(PacienteFilter filter);
    }
}
