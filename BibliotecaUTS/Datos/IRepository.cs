using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public interface IRepository<T> where T : class
    {
        void Agregar(T entidad);

        void Eliminar(T entidad);

        void Actualizar(T entidad);

        List<T> Todos();

        T ObtenerPorId(int id);
    }
}