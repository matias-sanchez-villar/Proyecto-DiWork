using controlador;
using dataAccess;
using System;
using System.Collections.Generic;

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
