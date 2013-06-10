using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaUTS.Models;
using Datos;
using Dominio;

namespace BibliotecaUTS.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Usuarios()
        {
            UsuariosViewModel uvm = new UsuariosViewModel();
            uvm.Usuarios = _usuarioRepository.Todos();
            return View(uvm);
        }
    }
}