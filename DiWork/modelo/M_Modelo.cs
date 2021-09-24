using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controlador;
using dataAccess;

namespace modelo
{
    class M_Modelo
    {
        public DataAcces datos { get; set; }
        public List<Modelo> lModelo { get; set; }

        public M_Modelo()
        {
            datos = new DataAcces();
        }

        public List<Modelo> listar()
        {
            lModelo = new List<Modelo>();

            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lModelo;
        }
    }
}
