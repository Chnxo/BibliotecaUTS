using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Datos
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public void Agregar(T entidad)
        {
            using (var contexto = new Contexto())
            {
                contexto.Set<T>().Add(entidad);
                contexto.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new Contexto())
            {
                contexto.Set<T>().Remove(contexto.Set<T>().Find(id));
                contexto.SaveChanges();
            }
        }

        public void Actualizar(T entidad)
        {
            using (var contexto = new Contexto())
            {
                contexto.Entry(entidad).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public List<T> Todos()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Set<T>().ToList();
            }
        }

        public T ObtenerPorId(int id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Set<T>().Find(id);
            }
        }
    }
}