using AppReservas.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Data
{
    public interface IEspecialidadRepository
    {
        List<EspecialidadDTO> Listar();
    }
}
