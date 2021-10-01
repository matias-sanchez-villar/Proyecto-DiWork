using System;
using controlador;
using modelo;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class presupuesto : System.Web.UI.Page
    {
        public Moto motos = new Moto();
        public List<Moto> lMoto = new List<Moto>();
        public M_Moto M_moto = new M_Moto();

        public List<Automovil> lAutomovil = new List<Automovil>();
        public M_Automovil M_automovil = new M_Automovil();
        public Automovil automovil = new Automovil();

        public Repuesto repuestos = new Repuesto();
        public List<Repuesto> lRepuesto = new List<Repuesto>();
        public M_Repuesto M_repuesto = new M_Repuesto();
        public List<Repuesto> LFRepuestos = new List<Repuesto>(); //Muestra la lista de repuestos seleccionados

        protected void Page_Load(object sender, EventArgs e)
        {
            agregarRepuestos();
        }


        protected void ddlTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPatente.Items.Clear();
            if (int.Parse(ddlTipoVehiculo.SelectedValue) == 1)
            {
                ListAutos();
            }
            else
            {
                ListMotos();
            }
        }

        public void ListAutos()
        {
            try
            {
                lAutomovil = M_automovil.listar();
                if (lAutomovil.Count == 0)
                {
                    ListItem listItemAux = new ListItem("Sin automoviles registrados", "#");
                    ddlPatente.Items.Add(listItemAux);
                    return;
                }

                foreach (controlador.Automovil item in lAutomovil)
                {
                    ListItem listItemAux = new ListItem(item.patente, item.patente);
                    ddlPatente.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ListMotos()
        {

            try
            {
                lMoto = M_moto.listar();
                if (lAutomovil.Count == 0)
                {
                    ListItem listItemAux = new ListItem("Sin motos registradas", "#");
                    ddlPatente.Items.Add(listItemAux);
                    return;
                }

                foreach (controlador.Moto item in lMoto)
                {
                    ListItem listItemAux = new ListItem(item.patente, item.patente);
                    ddlPatente.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarRepuestos()
        {
            if (IsPostBack) return;

            try
            {
                lRepuesto = M_repuesto.listar();

                if (lRepuesto.Count == 0)
                {
                    ListItem listItemAux = new ListItem("Sin repuestos registradas", "#");
                    ddlRepuestos.Items.Add(listItemAux);
                    return;
                }

                foreach (controlador.Repuesto item in lRepuesto)
                {
                    string txtRepuesto = item.nombre + "  $" + item.precio; 
                    ListItem listItemAux = new ListItem(txtRepuesto, item.ID.ToString());
                    ddlRepuestos.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void bntRepuesto_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }
    }
}