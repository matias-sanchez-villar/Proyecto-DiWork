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
    public partial class Motos : System.Web.UI.Page
    {
        public List<Marca> lMarca { get; set; }
        public M_Marca M_marca { get; set; }

        public List<Modelo> lModelo { get; set; }
        public M_Modelo M_modelo { get; set; }

        public Moto motos { get; set; }
        public List<Moto> lMoto { get; set; }
        public M_Moto M_moto { get; set; }

        public List<Moto> lFMoto = new List<Moto>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            agregarMarcas();
            lFMoto = agregarMotos();
            eliminarMoto();
        }

        public void eliminarMoto()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Patente"]))
                {
                    string Patente = Request.QueryString["Patente"];
                    M_moto = new M_Moto();
                    motos = new Moto();
                    motos = M_moto.listar(Patente);
                    motos.estado = false;
                    M_moto.modificar(motos);
                    Response.Redirect("Motos.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Moto> agregarMotos()
        {
            M_moto = new M_Moto();
            lMoto = new List<Moto>();

            try
            {
                lMoto = M_moto.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lMoto;
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
            if (string.IsNullOrEmpty(txtCilindrada.Text)) return;
            if (string.IsNullOrEmpty(txtPatente.Text)) return;

            motos = new Moto();
            M_moto = new M_Moto();
            try
            {
                motos.modelo.IDMarca = Convert.ToInt32(ddlMarca.SelectedValue);
                motos.modelo.IDModelo = Convert.ToInt32(ddlModelo.SelectedValue);
                motos.cilindrada = int.Parse(txtCilindrada.Text);
                motos.patente = txtPatente.Text;
                M_moto.agregar(motos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect("Motos.aspx");
        }
    }
}