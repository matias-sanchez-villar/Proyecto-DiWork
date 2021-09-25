using controlador;
using dataAccess;
using System;
using System.Collections.Generic;

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
            string select = "select * from Marcas";

            try
            {
                datos.setearConsulta(select);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.ID = (int)datos.Lector["ID"];
                    marca.nombre = (string)datos.Lector["nombre"];
                    marca.estado = Convert.ToBoolean(datos.Lector["estado"]);

                    lMarca.Add(marca);
                }
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

        public List<Marca> listar(int id)
        {
            lMarca = new List<Marca>();
            string select = "select * from Marcas";
            string where = "where ID = " + id;

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.ID = (int)datos.Lector["ID"];
                    marca.nombre = (string)datos.Lector["nombre"];
                    marca.estado = Convert.ToBoolean(datos.Lector["estado"]);

                    lMarca.Add(marca);
                }
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

        public void agregar(Marca marca)
        {
            try
            {
                datos.setearConsulta("insert into Marcas (nombre, estado) values (@nombre, @estado)");

                datos.setearParametro("@nombre", marca.nombre);
                datos.setearParametro("@estado", marca.estado);

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
