using CatalogoProductos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Datos.Repositorios
{
    public class RepositorioCliente
    {
        private readonly AccesoDatos _datos;

        public RepositorioCliente()
        {
            _datos = new AccesoDatos();
        }

        public Cliente ObtenerPorDni(string dni)
        {
            Cliente cliente = null;
            SqlDataReader lector;
            try
            {
                _datos.DefinirConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento");
                _datos.setearParametro("@Documento", dni);
                _datos.EjecutarConsulta();
                lector = _datos.Lector;

                if (lector.Read())
                {
                    cliente = new Cliente
                    {
                        Id = (int)lector["Id"],
                        Dni = (string)lector["Documento"],
                        Nombre = (string)lector["Nombre"],
                        Apellido = (string)lector["Apellido"],
                        Email = (string)lector["Email"],
                        Direccion = (string)lector["Direccion"],
                        Ciudad = (string)lector["Ciudad"],
                        CodigoPostal = (int)lector["CP"],
                    };
                }

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _datos.CerrarConexion();
            }
        }
    }
}
