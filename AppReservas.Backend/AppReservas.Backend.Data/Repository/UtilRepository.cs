using System;
using System.Collections.Generic;
using System.Text;
using AppReservas.Backend.Data;
using AppReservas.Backend.Entity;
using Microsoft.Data.SqlClient;

namespace AppReservas.Backend.Data.Repository
{
    public class UtilRepository : IUtilRepository
    {
        public List<CargoDTO> ListarCargos()
        {
            Conexion conexion = new Conexion();

            var lst = new List<CargoDTO>();
            try
            {
                String sql = @"SELECT  [IdCargo], [Descripcion], [Estado]  FROM [dbo].[Cargo]  WHERE [Estado] = 'A'";

                using (SqlCommand command = new SqlCommand(sql, conexion.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new CargoDTO();
                            obj.IdCargo = reader.GetInt32(0);
                            obj.Descripcion = reader.GetString(1);
                            obj.Estado = reader.GetString(2);
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

        public List<EspecialidadDTO> ListarEspecialidades()
        {
            Conexion conexion = new Conexion();

            var lst = new List<EspecialidadDTO>();
            try
            {
                String sql = @"SELECT  [IdEspecialidad], [Descripcion], [Estado]  FROM [dbo].[Especialidad]  WHERE [Estado] = 'A'";

                using (SqlCommand command = new SqlCommand(sql, conexion.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new EspecialidadDTO();
                            obj.IdEspecialidad = reader.GetInt32(0);
                            obj.Descripcion = reader.GetString(1);
                            obj.Estado = reader.GetString(2);
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

        public List<TipoDocumentoDTO> ListarTipoDocumento()
        {
            Conexion conexion = new Conexion();

            var lst = new List<TipoDocumentoDTO>();
            try
            {
                String sql = @"SELECT  [IdTipoDocumento], [Descripcion], [Estado]  FROM [dbo].[TipoDocumento]  WHERE [Estado] = 'A'";

                using (SqlCommand command = new SqlCommand(sql, conexion.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new TipoDocumentoDTO();
                            obj.IdTipoDocumento = reader.GetInt32(0);
                            obj.Descripcion = reader.GetString(1);
                            obj.Estado = reader.GetString(2);
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
    }
}
