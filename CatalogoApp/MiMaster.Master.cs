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
    public partial class MiMaster : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Login1 || Page is Default))
            {
            if (!Seguridad.sesionActiva(Session["sesionActiva"]))
                Response.Redirect("Login.aspx", false);

            }

            if (Seguridad.sesionActiva(Session["sesionActiva"])
                {
                imgAvatar.ImageUrl ="~/Imagenes/" + ((Usuario)Session["sesionActiva"]).ImagenPerfil;
                }
            else { imgAvatar.ImageUrl = "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled-1150x647.png"; }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}