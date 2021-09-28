using controlador;
using dataAccess;
using System;
using System.Collections.Generic;
using dataAccess;
using controlador;

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
            string select = " select * from Marcas ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.IDMarca = (int)datos.Lector["ID"];
                    marca.nombreMarca = (string)datos.Lector["nombre"];
                    marca.estadoMarca = Convert.ToBoolean(datos.Lector["estado"]);

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

        public Marca listar(int id)
        {
            lMarca = new List<Marca>();
            Marca marca = new Marca();

            string select = "select * from Marcas ";
            string where = " where estado = 1 and ID = " + id;

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                datos.Lector.Read();

                marca.IDMarca = (int)datos.Lector["ID"];
                marca.nombreMarca = (string)datos.Lector["nombre"];
                marca.estadoMarca = Convert.ToBoolean(datos.Lector["estado"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return marca;
        }

        public void agregar(Marca marca)
        {
            try
            {
                datos.setearConsulta("insert into Marcas (nombre, estado) values (@nombre, @estado)");

                datos.setearParametro("@nombre", marca.nombreMarca);
                datos.setearParametro("@estado", marca.estadoMarca);

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

        public void modificar(Marca marca)
        {
            try
            {
                datos.setearConsulta("update Marcas set nombre = @nombre, estado = @estado where ID = @ID");

                datos.setearParametro("@ID", marca.IDMarca);
                datos.setearParametro("@nombre", marca.nombreMarca);
                datos.setearParametro("@estado", marca.estadoMarca);

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
