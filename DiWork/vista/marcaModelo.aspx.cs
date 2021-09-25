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

        Marca marca;
        List<Marca> lMarca;
        M_Marca M_marca;

        Modelo modelo;
        M_Modelo M_modelo;


        protected void Page_Load(object sender, EventArgs e)
        {
            ddlMarca.Items.Clear();
            agregarMarcas();
        }

        public void agregarMarcas()
        {
            M_marca = new M_Marca();
            lMarca = new List<Marca>();

            try
            {
                lMarca = M_marca.listar();

                //vaciar el ddlMarcas en reinicio
                foreach (controlador.Marca item in lMarca)
                {
                    ListItem listItemAux = new ListItem(item.nombreMarca, item.IDMarca.ToString());
                    ddlMarca.Items.Add(listItemAux);
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnEnviarMarca_Click(object sender, EventArgs e)
        {
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
        }

        protected void btnEnviarModelo_Click(object sender, EventArgs e)
        {

            modelo = new Modelo();
            M_modelo = new M_Modelo();
            try
            {
                modelo.nombreMarca = ddlMarca.SelectedValue;
                modelo.IDMarca = ddlMarca.SelectedIndex;
                modelo.nombreMarca = txtModelo.Text;
                modelo.estadoMarca = true;
                M_modelo.agregar(modelo);
            }
            catch (Exception ex)
            {

            }

        }
    }
}