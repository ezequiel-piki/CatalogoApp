using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace CatalogoApp
{
    public partial class ListaArticulos : System.Web.UI.Page

    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["sesionActiva"])) {
                Session.Add("error","Se requiere permisos de admin para entrar a esta sección");
                Response.Redirect("Error.aspx");
            }

            FiltroAvanzado = checkAvanzado.Checked;
            if (!IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Session.Add("listaArticulos", articuloNegocio.listarConSP());
                dataGridViewArticulos.DataSource = Session["listaArticulos"];
                dataGridViewArticulos.DataBind();
            }
        }

        protected void dataGridViewArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGridViewArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dataGridViewArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridViewArticulos.PageIndex = e.NewPageIndex;
            dataGridViewArticulos.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];

            List<Articulo> listaFiltrada = listaArticulos.FindAll(ARTICULO => ARTICULO.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dataGridViewArticulos.DataSource = listaFiltrada;
            dataGridViewArticulos.DataBind();
        }

        protected void checkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = checkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
           if (ddlCampo.SelectedItem.ToString()=="Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                dataGridViewArticulos.DataSource = articuloNegocio
                                                                  .filtrar(ddlCampo.SelectedItem.ToString(),
                                                                   ddlCriterio.SelectedItem.ToString(),
                                                                   txtFiltroAvanzado.Text,
                                                                   ddlEstado.SelectedItem.ToString());
                dataGridViewArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
                throw;
            }
        }
    }
}