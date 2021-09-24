using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controlador;
using dataAccess;

namespace modelo
{
    public class M_Marca
    {
        public DataAcces datos { get; set; }
        public List<Marca> lMarca { get; set; }

        public M_Marca()
        {
            datos = new DataAcces();
        }

        public List<Marca> listar()
        {
            lMarca = new List<Marca>();

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

            return lMarca;
        }
    }
}
