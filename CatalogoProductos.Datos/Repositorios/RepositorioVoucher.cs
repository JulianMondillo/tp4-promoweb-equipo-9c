using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CatalogoProductos.Dominio.Entidades;

namespace CatalogoProductos.Datos.Repositorios
{
    public class RepositorioVoucher
    {

        public bool VoucherEsValido(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader lector;
            try
            {
                datos.DefinirConsulta("SELECT FechaCanje FROM Vouchers WHERE UPPER(CodigoVoucher) = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigo);
                datos.EjecutarConsulta();
                lector = datos.Lector;

                if (lector.Read())
                {
                    return lector["FechaCanje"] == DBNull.Value;
                }
                return false;
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

        public void Actualizar(Voucher nuevoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.DefinirConsulta(@"
                    UPDATE Vouchers 
                    SET idCliente = @idCliente, 
                        FechaCanje = @fechaCanje, 
                        IdArticulo = @idArticulo 
                    WHERE UPPER(CodigoVoucher) = UPPER(@codigoVoucher)
                ");

                datos.setearParametro("@idCliente", nuevoVoucher.Cliente.Id);
                datos.setearParametro("@fechaCanje", nuevoVoucher.FechaCanje);
                datos.setearParametro("@idArticulo", nuevoVoucher.Articulo.Id);
                datos.setearParametro("@codigoVoucher", nuevoVoucher.Codigo);
                datos.EjecutarAccion();
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
