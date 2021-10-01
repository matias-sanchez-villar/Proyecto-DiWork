using controlador;
using modelo;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlador;
using modelo;

namespace vista
{
    public partial class Automoviles : System.Web.UI.Page
    {
        public List<Marca> lMarca { get; set; }
        public M_Marca M_marca { get; set; }

        public List<Modelo> lModelo { get; set; }
        public M_Modelo M_modelo { get; set; }

        public List<Automovil> lAutomovil { get; set; }
        public M_Automovil M_automovil { get; set; }
        public Automovil automovil { get; set; }

        public List<Automovil> LFAutomovil= new List<Automovil>();

        public Automoviles()
        {
            automovil = new Automovil();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            agregarMarcas();
            agregarTipo();
            LFAutomovil = agregarAutomovil();
            eliminarAutomovil();
        }

        public void eliminarAutomovil()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Patente"]))
                {
                    string Patente = Request.QueryString["Patente"];
                    M_automovil = new M_Automovil();
                    automovil = new Automovil();
                    automovil = M_automovil.listar(Patente);
                    automovil.estado = false;
                    M_automovil.modificar(automovil);
                    Response.Redirect("Automoviles.aspx");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Automovil> agregarAutomovil()
        {
            M_automovil = new M_Automovil();
            lAutomovil = new List<Automovil>();
            try
            {
                lAutomovil = M_automovil.listar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lAutomovil;
        }

        public void agregarTipo()
        {
            int cont = 1;
            foreach (Tipo r in Enum.GetValues(typeof(Tipo)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(Tipo), r), cont.ToString());
                ddlTipo.Items.Add(item);
                cont++;
            }

        }

        public void agregarMarcas()
        {
            M_marca = new M_Marca();
            lMarca = new List<Marca>();

            try
            {
                lMarca = M_marca.listar();

                foreach (controlador.Marca item in lMarca)
                {
                    ListItem listItemAux = new ListItem(item.nombreMarca, item.IDMarca.ToString());
                    ddlMarca.Items.Add(listItemAux);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarModelos(int ID)
        {
            M_modelo = new M_Modelo();
            lModelo = new List<Modelo>();

            try
            {
                lModelo = M_modelo.listarModelosXMarcas(ID);

                if (lModelo.Count == 0)
                {
                    ListItem listItemAux = new ListItem("Sin marcas", "#");
                    ddlModelo.Items.Add(listItemAux);
                    return;
                }

                foreach (controlador.Modelo item in lModelo)
                {
                    ListItem listItemAux = new ListItem(item.nombreModelo, item.IDModelo.ToString());
                    ddlModelo.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlModelo.Items.Clear();
            agregarModelos(Convert.ToInt32(ddlMarca.SelectedValue));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPatente.Text)) return;
            automovil = new Automovil();
            M_automovil = new M_Automovil();
            try
            {
                automovil.modelo.IDMarca = Convert.ToInt32(ddlMarca.SelectedValue);
                automovil.modelo.IDModelo = Convert.ToInt32(ddlModelo.SelectedValue);
                automovil.tipo = (Tipo)int.Parse(ddlTipo.SelectedValue);
                automovil.cantidadPuertas = Convert.ToInt32(ddlPuerta.SelectedValue);
                automovil.patente = txtPatente.Text;

                M_automovil.agregar(automovil);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect("Automoviles.aspx");
        }
    }
}