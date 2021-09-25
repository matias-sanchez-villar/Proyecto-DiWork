using controlador;
using dataAccess;
using System;
using System.Collections.Generic;

namespace modelo
{
    public class M_Modelo
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

        public void agregar(Modelo modelo)
        {
            try
            {
                datos.setearConsulta("insert into Modelos (IDMarcas, nombre, estado) value (@IDMarcas, @nombre, @estado)");

                datos.setearParametro("@IDMarcas", modelo.IDMarca);
                datos.setearParametro("@nombre", modelo.nombreMarca);
                datos.setearParametro("@estado", modelo.estadoMarca);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
