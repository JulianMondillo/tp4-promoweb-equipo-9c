using CatalogoProductos.Datos.Repositorios;
using CatalogoProductos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Negocio.Clientes
{
    public class NegocioCliente
    {
        private readonly RepositorioCliente _repo;

        public NegocioCliente()
        {
            _repo = new RepositorioCliente();
        }

        public Cliente ObtenerPorDocumento(string documento)
        {
            try
            {
                return _repo.ObtenerPorDocumento(documento);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Registrar(Cliente nuevoCliente)
        {
            try
            {
                return _repo.Guardar(nuevoCliente);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Actualizar(Cliente cliente)
        {
            try
            {
                _repo.Actualizar(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
