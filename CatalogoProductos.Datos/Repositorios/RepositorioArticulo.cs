using CatalogoProductos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Datos.Repositorios
{
    public class RepositorioArticulo
    {
        private readonly AccesoDatos _datos;

        public RepositorioArticulo()
        {
            _datos = new AccesoDatos();
        }

       
    }
}
