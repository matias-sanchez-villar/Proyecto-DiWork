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
    public partial class marcaModelo : System.Web.UI.Page
    {
        public Marca marca { get; set; }
        public List<Marca> lMarca { get; set; }
        public M_Marca M_marca { get; set; }

        public List<Modelo> lModelo { get; set; }
        public M_Modelo M_modelo { get; set; }
        public Modelo modelo { get; set; }

        public marcaModelo()
        {
            //Constructor
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            ddlMarca.Items.Clear();
            lMarca = agregarMarcas();
            lModelo = agregarModelos();
        }

        public List<Marca> agregarMarcas()
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

                return lMarca;
            }
            catch(Exception ex)
            {

            }
            return lMarca;
        }

        public List<Modelo> agregarModelos()
        {
            M_modelo = new M_Modelo();
            lModelo = new List<Modelo>();

            try
            {
                lModelo = M_modelo.listar();
            }
            catch(Exception ex)
            {

            }

            return lModelo;
        }

        protected void btnEnviarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMarca.Text)) return;


            marca = new Marca();
            M_marca = new M_Marca();
            try
            {
                marca.nombreMarca = txtMarca.Text;
                M_marca.agregar(marca);
            }
            catch (Exception ex)
            {
                
            }
            Response.Redirect("marcaModelo.aspx");
        }

        protected void btnEnviarModelo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelo.Text)) return;

            modelo = new Modelo();
            M_modelo = new M_Modelo();
            try
            {
                modelo = new Modelo();
                modelo.IDMarca = int.Parse(ddlMarca.SelectedItem.Value);
                modelo.nombreMarca = ddlMarca.SelectedItem.Text;
                modelo.nombreModelo = txtModelo.Text;
                M_modelo.agregar(modelo);
            }
            catch (Exception ex)
            {

            }
            Response.Redirect("marcaModelo.aspx");
        }
    }
}