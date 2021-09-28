using AppReservas.Backend.Data.Interface;
using AppReservas.Backend.Entity;
using AppReservas.Backend.Entity.Request;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Data.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public List<EmpleadoDTO> Listar(EmpleadoFilter filter)
        {
            Conexion conexion = new Conexion();

            var lst = new List<EmpleadoDTO>();
            try
            {
                String sql = "SP_LISTAR_EMPLEADO";

                using (SqlCommand cmd = new SqlCommand(sql, conexion.GetConnection()))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdEmpleado", filter.IdEmpleado.HasValue ? filter.IdEmpleado : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pTipoDocumento", filter.IdTipoDocumento.HasValue ? filter.IdTipoDocumento : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNroDocumento", !string.IsNullOrEmpty(filter.NroDocumento) ? filter.NroDocumento.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNombres", !string.IsNullOrEmpty(filter.Nombres) ? filter.Nombres.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoPaterno", !string.IsNullOrEmpty(filter.ApellidoPaterno) ? filter.ApellidoPaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoMaterno", !string.IsNullOrEmpty(filter.ApellidoMaterno) ? filter.ApellidoMaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pSexo", !string.IsNullOrEmpty(filter.Sexo) ? filter.Sexo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pIdCargo", filter.IdCargo.HasValue ? filter.IdCargo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEstado", !string.IsNullOrEmpty(filter.Estado) ? filter.Estado : (object)DBNull.Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new EmpleadoDTO();
                            obj.IdEmpleado = reader.GetInt32(0);
                            obj.IdTipoDocumento = reader.GetInt32(1);
                            obj.TipoDocumento = reader.GetString(2);
                            obj.IdCargo = reader.GetInt32(3);
                            obj.Cargo = reader.GetString(4);
                            obj.NumeroDocumento = reader.GetString(5);
                            obj.Nombres = reader.GetString(6);
                            obj.ApellidoPaterno = reader.GetString(7);
                            obj.ApellidoMaterno = reader.GetString(8);
                            obj.Sexo = reader.GetString(9);
                            obj.Telefono = reader.GetString(10);
                            obj.Email = reader.GetString(11);
                            obj.Pass = reader.GetString(12);
                            obj.Estado = reader.GetString(13);
                            lst.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public int MantenerEmpleado(EmpleadoRequest request)
        {
            int result = 0;
            Conexion conexion = new Conexion();

            var lst = new List<EmpleadoDTO>();
            try
            {
                String sql = "SP_MANT_EMPLEADO";

                using (SqlCommand cmd = new SqlCommand(sql, conexion.GetConnection()))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pAccion", request.Accion);
                    cmd.Parameters.AddWithValue("@pIdEmpleado", request.empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@pTipoDocumento", request.empleado.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@pNroDocumento", !string.IsNullOrEmpty(request.empleado.NumeroDocumento) ? request.empleado.NumeroDocumento.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNombres", !string.IsNullOrEmpty(request.empleado.Nombres) ? request.empleado.Nombres.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoPaterno", !string.IsNullOrEmpty(request.empleado.ApellidoPaterno) ? request.empleado.ApellidoPaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoMaterno", !string.IsNullOrEmpty(request.empleado.ApellidoMaterno) ? request.empleado.ApellidoMaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pSexo", !string.IsNullOrEmpty(request.empleado.Sexo) ? request.empleado.Sexo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pTelefono", !string.IsNullOrEmpty(request.empleado.Telefono) ? request.empleado.Telefono : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEmail", !string.IsNullOrEmpty(request.empleado.Email) ? request.empleado.Email : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pPass", !string.IsNullOrEmpty(request.empleado.Pass) ? request.empleado.Pass : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pIdCargo", request.empleado.IdCargo);
                    cmd.Parameters.AddWithValue("@pEstado", !string.IsNullOrEmpty(request.empleado.Estado) ? request.empleado.Estado : (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                result = -1;
                throw ex;
            }
            return result;
        }
    }
}
