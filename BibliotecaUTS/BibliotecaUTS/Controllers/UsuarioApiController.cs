using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos;
using Dominio;

namespace BibliotecaUTS.Controllers
{
    public class UsuarioApiController : ApiController
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioApiController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET api/usuarioapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/usuarioapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/usuarioapi
        public int Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Agregar(usuario);
            }
            catch
            {
            }

            return usuario.IdUsuario;
        }

        // PUT api/usuarioapi/5
        public void Put(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Actualizar(usuario);
            }
            catch
            {
                
            }
        }

        // DELETE api/usuarioapi/5
        public void Delete(int usuarioId)
        {
            try
            {
                _usuarioRepository.Eliminar(usuarioId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}