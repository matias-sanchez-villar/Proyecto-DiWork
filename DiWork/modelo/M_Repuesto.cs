using controlador;
using dataAccess;
using System;
using System.Collections.Generic;

namespace modelo
{
    public class M_Repuesto
    {
        public DataAcces datos { get; set; }
        public List<Repuesto> lRepuesto { get; set; }

        public M_Repuesto()
        {
            datos = new DataAcces();
        }

        public List<Repuesto> listar()
        {
            lRepuesto = new List<Repuesto>();

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

            return lRepuesto;
        }
    }
}
