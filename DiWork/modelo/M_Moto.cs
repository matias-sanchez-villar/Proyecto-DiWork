using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccess;
using controlador;

namespace modelo
{
    public class M_Moto
    {
        public DataAcces datos { get; set; }
        public List<Moto> lMoto { get; set; }

        public M_Moto()
        {
            datos = new DataAcces();
        }

        public List<Moto> listar()
        {
            lMoto = new List<Moto>();
            M_Marca marca = new M_Marca();
            M_Modelo modelo = new M_Modelo();
 
            string select = " select * from Motos ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Moto moto = new Moto();

                    moto.modelo = modelo.listar((int)datos.Lector["IDModelo"]).Find(x => x.IDMarca == (int)datos.Lector["IDMarca"]);
                    moto.patente = (string)datos.Lector["patente"];
                    moto.cilindrada = (int)datos.Lector["cilindrara"];
                    moto.estado = Convert.ToBoolean(datos.Lector["estado"]);

                    lMoto.Add(moto);
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

            return lMoto;
        }


        public Moto listar(int id)
        {
            Moto moto = new Moto();
            lMoto = new List<Moto>();
            M_Marca marca = new M_Marca();
            M_Modelo modelo = new M_Modelo();

            string select = " select * from Motos ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                datos.Lector.Read();

                moto.modelo = modelo.listar((int)datos.Lector["IDModelo"]).Find(x => x.IDMarca == (int)datos.Lector["IDMarca"]);
                moto.patente = (string)datos.Lector["patente"];
                moto.cilindrada = (int)datos.Lector["cilindrara"];
                moto.estado = Convert.ToBoolean(datos.Lector["estado"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return moto;
        }

        public void agregar(Moto moto)
        {
            try
            {
                datos.setearConsulta(" insert into Motos (IDMarca, IDModelo, patente, cilindrada, estado) values (@IDMarca, @IDModelo, @patente, @cilindrada, @estado) ");
                
                datos.setearParametro("@IDMarca", moto.modelo.IDMarca);
                datos.setearParametro("@IDModelo", moto.modelo.IDModelo);
                datos.setearParametro("@patente", moto.patente);
                datos.setearParametro("@cilindrada", moto.cilindrada);
                datos.setearParametro("@estado", moto.estado);

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

        public void modificar(Moto moto)
        {
            try
            {
                datos.setearConsulta(" update Motos set cilindrada = @cilindrada, estado = @estado where IDMarca = @IDMarca, IDModelo = @IDModelo, patente = @patente ");

                datos.setearParametro("@IDMarca", moto.modelo.IDMarca);
                datos.setearParametro("@IDModelo", moto.modelo.IDModelo);
                datos.setearParametro("@patente", moto.patente);
                datos.setearParametro("@cilindrada", moto.cilindrada);
                datos.setearParametro("@estado", moto.estado);

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
