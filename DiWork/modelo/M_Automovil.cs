﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controlador;
using dataAccess;

namespace modelo
{
    public class M_Automovil
    {
        public DataAcces datos { get; set; }
        public List<Automovil> lAutomovil { get; set; }

        public M_Automovil()
        {
            datos = new DataAcces();
        }

        public List<Automovil> listar()
        {
            lAutomovil = new List<Automovil>();
            M_Marca marca = new M_Marca();
            M_Modelo modelo = new M_Modelo();
            string select = " select * from Automoviles ";
            string where = "  where estado = 1 ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Automovil auto = new Automovil();

                    auto.modelo = modelo.listar((int)datos.Lector["IDModelo"]).Find(x => x.IDMarca == (int)datos.Lector["IDMarca"]);
                    auto.patente = (string)datos.Lector["patente"];
                    string tipo = (String)datos.Lector["tipo"];
                    auto.tipo = (Tipo)Enum.Parse(typeof(Tipo), tipo);
                    auto.cantidadPuertas = (int)datos.Lector["cantidadPuetas"];
                    auto.estado = Convert.ToBoolean(datos.Lector["estado"]);

                    lAutomovil.Add(auto);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lAutomovil;
        }

        public Automovil listar(string patente)
        {
            Automovil auto = new Automovil();
            M_Marca marca = new M_Marca();
            M_Modelo modelo = new M_Modelo();
            string select = " select * from Automoviles ";
            string where = "  where estado = 1 and patente = '" + patente + "' ";

            try
            {
                datos.setearConsulta(select + where);
                datos.ejecutarLectura();

                datos.Lector.Read();
                    

                auto.modelo = modelo.listar((int)datos.Lector["IDModelo"]).Find(x => x.IDMarca == (int)datos.Lector["IDMarca"]);
                auto.patente = (string)datos.Lector["patente"];
                string tipo = (String)datos.Lector["tipo"];
                auto.tipo = (Tipo)Enum.Parse(typeof(Tipo), tipo);
                auto.cantidadPuertas = (int)datos.Lector["cantidadPuetas"];
                auto.estado = Convert.ToBoolean(datos.Lector["estado"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return auto;
        }

        public void agregar(Automovil auto)
        {
            try
            {
                datos.setearConsulta("addAutomovil @IDMarca, @IDModelo, @Patente, @tipo, @CantidadPuertas");

                datos.setearParametro("@IDMarca", auto.modelo.IDMarca);
                datos.setearParametro("@IDModelo", auto.modelo.IDModelo);
                datos.setearParametro("@Patente", auto.patente);
                datos.setearParametro("@Tipo", auto.tipo.ToString());
                datos.setearParametro("@CantidadPuertas", auto.cantidadPuertas);

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

        public void modificar(Automovil auto)
        {
            try
            {
                datos.setearConsulta("ModifyAutomovil @IDMarca, @IDModelo, @Patente, @tipo, @CantidadPuertas, @Estado");

                datos.setearParametro("@IDMarca", auto.modelo.IDMarca);
                datos.setearParametro("@IDModelo", auto.modelo.IDModelo);
                datos.setearParametro("@Patente", auto.patente);
                datos.setearParametro("@Tipo", auto.tipo.ToString());
                datos.setearParametro("@CantidadPuertas", auto.cantidadPuertas);
                datos.setearParametro("@Estado", auto.estado);
                
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
