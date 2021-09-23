using AppReservas.Backend.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Data.Repository
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        public List<EspecialidadDTO> Listar()
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
    }
}
