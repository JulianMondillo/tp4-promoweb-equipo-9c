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
        private readonly AccesoDatos _datos;

        public RepositorioVoucher()
        {
            _datos = new AccesoDatos();
        }

        public bool VoucherEsValido(string codigo)
        {
            SqlDataReader lector;
            try
            {
                _datos.DefinirConsulta("SELECT FechaCanje FROM Vouchers WHERE UPPER(CodigoVoucher) = @CodigoVoucher");
                _datos.setearParametro("@CodigoVoucher", codigo);
                _datos.EjecutarConsulta();
                lector = _datos.Lector;

                if (lector.Read())
                {
                    return lector["FechaCanje"] == DBNull.Value;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            } finally
            {
                _datos.CerrarConexion();
            }
        }

    }
}
