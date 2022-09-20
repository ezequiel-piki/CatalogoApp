using System;
using System.Collections.Generic;
using System.Text;
using dominio;

namespace Security
{
    public static class Security
    {
        public static bool sesionActiva(object user) {
            Usuario usuario = user != null ? (Usuario)user : null;

            if (!(usuario != null && usuario.Id != 0))
                return true;
            else
                return false;
        }
    }
}
