using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controlador;
using dataAccess;

namespace modelo
{
    public class M_Desperfecto
    {
        public DataAcces datos { get; set; }
        public List<Desperfecto> lDesperfecto { get; set; }

        public M_Desperfecto()
        {
            datos = new DataAcces();
        }


        public List<Desperfecto> listar(int id)
        {
            lDesperfecto = new List<Desperfecto>();
            string select = "";
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Desperfecto desperfecto = new Desperfecto();

                    desperfecto.ID = (int)datos.Lector["ID"];
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lDesperfecto;
        }

    }
}
