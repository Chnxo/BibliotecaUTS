using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace BibliotecaUTS.Models
{
    public class UsuariosViewModel
    {
        public UsuariosViewModel()
        {
            Usuario = new Usuario();
            Usuarios = new List<Usuario>();
        }

        public Usuario Usuario { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}