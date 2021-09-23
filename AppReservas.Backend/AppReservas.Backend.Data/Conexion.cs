using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace AppReservas.Backend.Data
{
    public class Conexion
    {

        public SqlConnection GetConnection()
        {
            SqlConnection cn;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "srvupctest.database.windows.net";
            builder.UserID = "test";
            builder.Password = "Upc.2021";
            builder.InitialCatalog = "Reservas";
            cn = new SqlConnection(builder.ConnectionString);


            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return cn;
        }
    }
}
