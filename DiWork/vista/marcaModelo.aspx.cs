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

        protected void btnEnviarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMarca.Text)) return;


            marca = new Marca();
            M_marca = new M_Marca();
            try
            {
                marca.nombreMarca = txtMarca.Text;
                marca.estadoMarca = true;
                M_marca.agregar(marca);
            }
            catch (Exception ex)
            {
                
            }
            txtMarca.Text = String.Empty;
        }

        protected void btnEnviarModelo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelo.Text)) return;

            modelo = new Modelo();
            M_modelo = new M_Modelo();
            try
            {
                modelo.nombreMarca = ddlMarca.SelectedValue;
                modelo.IDMarca = (int)ddlMarca.SelectedIndex;
                modelo.nombreModelo = txtModelo.Text;
                modelo.estadoModelo = true;
                M_modelo.agregar(modelo);
            }
            catch (Exception ex)
            {

            }
            txtModelo.Text = String.Empty;
        }
    }
}