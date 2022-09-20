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
    public partial class FormularioArticulo : System.Web.UI.Page
    {  
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //Configuración inicial de la pantalla
                if (!IsPostBack)

                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> listaCategorias = categoriaNegocio.listar();

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarcas = marcaNegocio.listar();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                //configuración si estamos modificando

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if ((id != "") && (!IsPostBack)) {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    //List<Articulo> listaArticulos = articuloNegocio.listar(id);
                    //Articulo articuloSeleccionado = listaArticulos[0];
                    Articulo articuloSeleccionado = (articuloNegocio.listar(id))[0];

                    //Guardo articulo seleccionado en sesion
                    Session.Add("articuloSeleccionado",articuloSeleccionado);

                    //pre cargar todos los campos
                    txtId.Text = id;
                    txtCodigo.Text = articuloSeleccionado.Codigo;
                    txtNombre.Text = articuloSeleccionado.Nombre;
                    txtDescripcion.Text = articuloSeleccionado.Descripcion;
                    txtImagenUrl.Text = articuloSeleccionado.ImagenUrl;
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();

                    ddlMarca.SelectedValue = articuloSeleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = articuloSeleccionado.Categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    //configurar acciones
                    if (!articuloSeleccionado.Activo)
                        btnDesactivar.Text = "Reactivar";
                }
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
                throw;
                //redireccion a pantalla de error
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevoArticulo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                nuevoArticulo.Codigo = txtCodigo.Text;
                nuevoArticulo.Nombre = txtNombre.Text;
                nuevoArticulo.Descripcion = txtDescripcion.Text;
              


                nuevoArticulo.Marca = new Marca();
                nuevoArticulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevoArticulo.Categoria = new Categoria();
                nuevoArticulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevoArticulo.ImagenUrl = txtImagenUrl.Text;
                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text.ToString());

                if (Request.QueryString["id"] != null)
                {
                    nuevoArticulo.Id = int.Parse(txtId.Text);
                    articuloNegocio.updateArticuloConStoreProcedure(nuevoArticulo);
                }
                else
                articuloNegocio.addArticuloConStoreProcedure(nuevoArticulo);


                Response.Redirect("ListaArticulos.aspx", false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("ListaArticulos.aspx");

                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
               
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = (Articulo)Session["articuloSeleccionado"];
                articuloNegocio.eliminarLogico(articuloSeleccionado.Id, !articuloSeleccionado.Activo);
                Response.Redirect("ListaArticulos.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
            }
        }
    }
}