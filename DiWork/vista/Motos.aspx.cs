using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modelo;
using controlador;

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            agregarMarcas();
            lMoto = agregarMotos();
        }

        public List<Moto> agregarMotos()
        {
            M_moto = new M_Moto();
            lMoto = new List<Moto>();

            try
            {
                lMoto = M_moto.listar();
            }
            catch(Exception ex)
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
                lModelo = M_modelo.listar(ID);
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
            
        }
    }
}