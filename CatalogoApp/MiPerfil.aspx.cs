using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace CatalogoApp
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                string route = Server.MapPath("./Images/");
                Usuario usuario = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(route + "perfil-" + usuario.Id+".jpg");

                usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                usuarioNegocio.actualizar(usuario);
               Image image = (Image) Master.FindControl("imgAvatar");
                image.ImageUrl = "~/Imagenes/"+usuario.ImagenPerfil;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}