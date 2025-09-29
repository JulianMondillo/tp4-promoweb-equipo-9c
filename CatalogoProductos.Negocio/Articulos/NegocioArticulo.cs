using CatalogoProductos.Datos.Repositorios;
using CatalogoProductos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Negocio.Articulos
{
    public class NegocioArticulo
    {
        private readonly RepositorioArticulo _repo;

        public NegocioArticulo()
        {
            _repo = new RepositorioArticulo();
        }

        public List<Articulo> Listar()
        {
            try
            {
                return _repo.Listar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
