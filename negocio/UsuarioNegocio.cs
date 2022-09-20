using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class UsuarioNegocio
    {
        //id
        //email
        //pass
        //admin false

        //nombre, apellido, imagen, fechanacimiento

        public int insertarNuevo(Usuario nuevoUsuario)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setProcedure("insertarNuevo");
                data.setearParametro("@email", nuevoUsuario.Email);
                data.setearParametro("@pass", nuevoUsuario.Pass);
               return data.ejecutarAccionScalar();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public bool login(Usuario usuario) {

            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("select id, email, pass, admin, imagenPerfil from USERS where email=@email and pass=@pass");
                data.setearParametro("@email",usuario.Email);
                data.setearParametro("@pass",usuario.Pass);
                data.ejecutarLectura();

                if (data.LectorSQL.Read()) {
                    usuario.Id = (int)data.LectorSQL["id"];
                    usuario.Admin = (bool)data.LectorSQL["admin"];
                    if(!(data.LectorSQL["imagenPerfil"] is DBNull))
                    usuario.ImagenPerfil = (string)data.LectorSQL["imagenPerfil"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public void actualizar(Usuario usuario)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("update USERS set imagenPerfil = @imagen where Id = @id ");
                data.setearParametro("@imagen", usuario.ImagenPerfil);
                data.setearParametro("@id",usuario.Id);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }finally{
                data.cerrarConexion();
            }
        }
    }
}
