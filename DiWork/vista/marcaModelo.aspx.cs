using controlador;
using modelo;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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

        public List<Marca> lFMarca = new List<Marca>();
        public List<Modelo> lFModelo = new List<Modelo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lFMarca = agregarMarcas();
            lFModelo = agregarModelos();
            eliminarMarca();
            eliminarModelo();
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
                    DDLM.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }

            return lModelo;
        }

        public void eliminarMarca()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["IDMarca"]))
                {
                    int IDMarca = int.Parse(Request.QueryString["IDMarca"]);
                    M_marca = new M_Marca();
                    marca = new Marca();
                    marca = M_marca.listar(IDMarca);
                    marca.estadoMarca = false;
                    M_marca.modificar(marca);

                    Response.Redirect("marcaModelo.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarModelo()
        {
            try
            {
                if (String.IsNullOrEmpty(Request.QueryString["IDModelo"])) return;
                if (String.IsNullOrEmpty(Request.QueryString["ID"])) return;

                int IDMarca = int.Parse(Request.QueryString["ID"]);
                int IDModelo = int.Parse(Request.QueryString["IDModelo"]);
                M_modelo = new M_Modelo();
                modelo = new Modelo();
                modelo = M_modelo.listar(IDModelo).Find(x => x.IDMarca == IDMarca);
                modelo.estadoModelo = false;
                M_modelo.modificar(modelo);

                Response.Redirect("marcaModelo.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                throw ex;
            }
            Response.Redirect("marcaModelo.aspx");
        }

        protected void btnEnviarModelo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelo.Text)) return;
            M_modelo = new M_Modelo();
            try
            {
                modelo = new Modelo();
                modelo.IDMarca = Convert.ToInt32(DDLM.SelectedValue);
                modelo.nombreMarca = DDLM.SelectedItem.Text;
                modelo.nombreModelo = txtModelo.Text;
                M_modelo.agregar(modelo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect("marcaModelo.aspx");
        }
    }
}