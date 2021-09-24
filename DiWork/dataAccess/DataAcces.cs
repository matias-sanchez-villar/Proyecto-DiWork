using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dataAccess
{
    public class DataAcces
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private string cadenaConexion = "data source = (local)\\SQLEXPRESS; initial catalog =DiWork; integrated security = true;";


        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public DataAcces()
        {
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
