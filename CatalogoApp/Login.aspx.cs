﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace CatalogoApp
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;

                if (usuarioNegocio.login(usuario))
                {
                    Session.Add("sesionActiva",usuario);
                    Response.Redirect("MiPerfil.aspx",false);
                }
                else
                {
                    Session.Add("error","User o Pass incorrectos");
                    Response.Redirect("Error.aspx",false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error",ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}