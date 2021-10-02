using AppReservas.Backend.Entity;
using AppReservas.Backend.Entity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Data.Interface
{
    public interface IEmpleadoRepository
    {
        int MantenerEmpleado(EmpleadoRequest request);
        List<EmpleadoDTO> Listar();
    }
}
