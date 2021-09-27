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
            string select = " select * from Repuestos ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Repuesto repuesto = new Repuesto();

                    repuesto.ID = (int)datos.Lector["ID"];
                    repuesto.nombre = (string)datos.Lector["nombre"];
                    repuesto.precio = decimal.Round((decimal)datos.Lector["precio"], 2);
                    repuesto.estado = Convert.ToBoolean(datos.Lector["estado"]);

                    lRepuesto.Add(repuesto);
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

            return lRepuesto;
        }


        public Repuesto listar(int id)
        {
            Repuesto repuesto = new Repuesto();
            lRepuesto = new List<Repuesto>();
            string select = " select * from Repuestos ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                datos.Lector.Read();

                repuesto.ID = (int)datos.Lector["ID"];
                repuesto.nombre = (string)datos.Lector["nombre"];
                repuesto.precio = decimal.Round((decimal)datos.Lector["precio"], 2);
                repuesto.estado = Convert.ToBoolean(datos.Lector["estado"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return repuesto;
        }

        public void agregar(Repuesto repuesto)
        {
            try
            {
                datos.setearConsulta(" insert into Repuestos (nombre, precio, estado) values (@nombre, @precio, @estado) ");

                datos.setearParametro("@nombre", repuesto.nombre);
                datos.setearParametro("@precio", repuesto.precio);
                datos.setearParametro("@estado", repuesto.estado);

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

        public void modificar(Repuesto repuesto)
        {
            try
            {
                datos.setearConsulta("update Repuestos set nombre = @nombre, precio = @precio, estado = @estado where ID = @ID");

                datos.setearParametro("@ID", repuesto.ID);
                datos.setearParametro("@nombre", repuesto.nombre);
                datos.setearParametro("@precio", repuesto.precio);
                datos.setearParametro("@estado", repuesto.estado);

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
