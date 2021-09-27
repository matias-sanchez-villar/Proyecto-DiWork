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
            string select = "select ma.ID IDMa, ma.nombre nombreMa, ma.estado estadoMa, mo.ID IDMo, mo.nombre nombreMo, mo.estado estadoMo from Modelos mo  ";
            string inner = " inner join Marcas ma on ma.ID = mo.IDMarcas ";
            string where = "  where ma.estado = 1 and mo.estado = 1 ";

            try
            {
                datos.setearConsulta(select + inner + where);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Modelo modelo = new Modelo();

                    modelo.IDModelo = (int)datos.Lector["IDMo"];
                    modelo.nombreModelo = (string)datos.Lector["nombreMo"];
                    modelo.estadoModelo = Convert.ToBoolean(datos.Lector["estadoMo"]);

                    modelo.IDMarca = (int)datos.Lector["IDMa"];
                    modelo.nombreMarca = (string)datos.Lector["nombreMa"];
                    modelo.estadoMarca = Convert.ToBoolean(datos.Lector["estadoMa"]);

                    lModelo.Add(modelo);
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

            return lModelo;
        }

        public Modelo listar(int ID)
        {
            Modelo modelo = new Modelo();
            string select = "select ma.ID IDMa, ma.nombre nombreMa, ma.estado estadoMa, mo.ID IDMo, mo.nombre nombreMo, mo.estado estadoMo from Modelos mo  ";
            string inner = " inner join Marcas ma on ma.ID = mo.IDMarcas  ";
            string where = "  where ma.estado = 1 and mo.estado = 1 and mo.ID = " + ID;

            try
            {
                datos.setearConsulta(select + inner + where);
                datos.ejecutarLectura();

                datos.Lector.Read();

                modelo.IDModelo = (int)datos.Lector["IDMo"];
                modelo.nombreModelo = (string)datos.Lector["nombreMo"];
                modelo.estadoModelo = Convert.ToBoolean(datos.Lector["estadoMo"]);

                modelo.IDMarca = (int)datos.Lector["IDMa"];
                modelo.nombreMarca = (string)datos.Lector["nombreMa"];
                modelo.estadoMarca = Convert.ToBoolean(datos.Lector["estadoMa"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return modelo;
        }


        public void agregar(Modelo modelo)
        {
            try
            {
                datos.setearConsulta("insert into Modelos (IDMarcas, nombre, estado) values (@IDMarcas, @nombre, @estado)");

                datos.setearParametro("@IDMarcas", modelo.IDMarca);
                datos.setearParametro("@nombre", modelo.nombreModelo);
                datos.setearParametro("@estado", modelo.estadoModelo);

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

        public void modificar(Modelo modelo)
        {
            try
            {
                datos.setearConsulta("update Modelos set nombre = @nombre, estado = @estado where ID = @ID");

                datos.setearParametro("@ID", modelo.IDModelo);
                datos.setearParametro("@nombre", modelo.nombreModelo);
                datos.setearParametro("@estado", modelo.estadoModelo);

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
