using AppReservas.Backend.Data;
using AppReservas.Backend.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        public List<PacienteDTO> Listar(PacienteFilter filter)
        {
            Conexion conexion = new Conexion();

            var lst = new List<PacienteDTO>();
            try
            {
                String sql = "SP_LISTAR_PACIENTE";

                using (SqlCommand cmd = new SqlCommand(sql, conexion.GetConnection()))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdPaciente", filter.IdPaciente.HasValue ? filter.IdPaciente : (object) DBNull.Value);
                    cmd.Parameters.AddWithValue("@pTipoDocumento", filter.IdTipoDocumento.HasValue ? filter.IdTipoDocumento : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNroDocumento",  !string.IsNullOrEmpty(filter.NroDocumento) ? filter.NroDocumento.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNombres", !string.IsNullOrEmpty(filter.Nombres) ? filter.Nombres.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoPaterno", !string.IsNullOrEmpty(filter.ApellidoPaterno) ? filter.ApellidoPaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoMaterno", !string.IsNullOrEmpty(filter.ApellidoMaterno) ? filter.ApellidoMaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pSexo", !string.IsNullOrEmpty(filter.Sexo) ? filter.Sexo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEstado", !string.IsNullOrEmpty(filter.Estado) ? filter.Estado : (object)DBNull.Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new PacienteDTO();
                            obj.IdPaciente = reader.GetInt32(0);
                            obj.IdTipoDocumento = reader.GetInt32(1);
                            obj.TipoDocumento = reader.GetString(2);
                            obj.Nombres = reader.GetString(3);
                            obj.ApellidoPaterno = reader.GetString(4);
                            obj.ApellidoMaterno = reader.GetString(5);
                            obj.Sexo = reader.GetString(6);
                            obj.Telefono = reader.GetString(7);
                            obj.Pass = reader.GetString(8);
                            obj.Estado = reader.GetString(9);
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

        public int MantenerPaciente(int nAccion, PacienteDTO paciente)
        {
            int result = 0;
            Conexion conexion = new Conexion();

            var lst = new List<PacienteDTO>();
            try
            {
                String sql = "SP_MANT_PACIENTE";

                using (SqlCommand cmd = new SqlCommand(sql, conexion.GetConnection()))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdPaciente", nAccion);
                    cmd.Parameters.AddWithValue("@pIdPaciente", paciente.IdPaciente.HasValue ? paciente.IdPaciente : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pTipoDocumento", paciente.IdTipoDocumento.HasValue ? paciente.IdTipoDocumento : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNroDocumento", !string.IsNullOrEmpty(paciente.NroDocumento) ? paciente.NroDocumento.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pNombres", !string.IsNullOrEmpty(paciente.Nombres) ? paciente.Nombres.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoPaterno", !string.IsNullOrEmpty(paciente.ApellidoPaterno) ? paciente.ApellidoPaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pApellidoMaterno", !string.IsNullOrEmpty(paciente.ApellidoMaterno) ? paciente.ApellidoMaterno.Trim() : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pSexo", !string.IsNullOrEmpty(paciente.Sexo) ? paciente.Sexo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pTelefono", !string.IsNullOrEmpty(paciente.Telefono) ? paciente.Telefono : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEmail", !string.IsNullOrEmpty(paciente.Email) ? paciente.Email : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pPass", !string.IsNullOrEmpty(paciente.Pass) ? paciente.Pass : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@pEstado", !string.IsNullOrEmpty(paciente.Estado) ? paciente.Estado : (object)DBNull.Value);

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
