using controlador;
using modelo;
using System;
using System.Collections.Generic;


namespace vista
{
    public partial class repuesto : System.Web.UI.Page
    {
        public Repuesto repuestos { get; set; }
        public List<Repuesto> lRepuesto { get; set; }
        public M_Repuesto M_repuesto { get; set; }

        public List<Repuesto> lFRepuesto = new List<Repuesto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lFRepuesto = agregarRepuesto();
            eliminarRepuesto();
        }

        public List<Repuesto> agregarRepuesto()
        {
            M_repuesto = new M_Repuesto();
            lRepuesto = new List<Repuesto>();

            try
            {
                lRepuesto = M_repuesto.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lRepuesto;
        }

        public void eliminarRepuesto()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int ID = int.Parse(Request.QueryString["ID"]);
                    M_repuesto = new M_Repuesto();
                    repuestos = new Repuesto();
                    repuestos = M_repuesto.listar(ID);
                    repuestos.estado = false;
                    M_repuesto.modificar(repuestos);

                    Response.Redirect("repuesto.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) return;
            if (string.IsNullOrEmpty(txtPrecio.Text)) return;
            if (Convert.ToDecimal(txtPrecio.Text) < 0) return;

            repuestos = new Repuesto();
            M_repuesto = new M_Repuesto();

            try
            {
                repuestos.nombre = txtNombre.Text;
                repuestos.precio = Convert.ToDecimal(txtPrecio.Text);
                M_repuesto.agregar(repuestos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect("repuesto.aspx");
        }
    }
}