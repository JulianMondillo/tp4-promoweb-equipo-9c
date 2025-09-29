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

        public Cliente ObtenerPorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = null;
            SqlDataReader lector;
            try
            {
                datos.DefinirConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento");
                datos.setearParametro("@Documento", documento);
                datos.EjecutarConsulta();
                lector = datos.Lector;

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
                datos.CerrarConexion();
            }
        }

        public int Guardar(Cliente nuevoCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.DefinirConsulta(@"
                    INSERT INTO Clientes 
                    VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ");

                datos.setearParametro("@Documento", nuevoCliente.Dni);
                datos.setearParametro("@Nombre", nuevoCliente.Nombre);
                datos.setearParametro("@Apellido", nuevoCliente.Apellido);
                datos.setearParametro("@Email", nuevoCliente.Email);
                datos.setearParametro("@Direccion", nuevoCliente.Direccion);
                datos.setearParametro("@Ciudad", nuevoCliente.Ciudad);
                datos.setearParametro("@CP", nuevoCliente.CodigoPostal);

                return datos.EjecutarAccionEscalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
