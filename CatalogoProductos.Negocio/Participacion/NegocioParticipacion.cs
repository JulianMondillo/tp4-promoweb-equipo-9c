using CatalogoProductos.Dominio.Entidades;
using CatalogoProductos.Negocio.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Negocio.Participacion
{
    public class NegocioParticipacion
    {

        private readonly NegocioCliente _negocioCliente;
        private readonly NegocioVoucher _negocioVoucher;

        public NegocioParticipacion()
        {
            _negocioCliente = new NegocioCliente();
            _negocioVoucher = new NegocioVoucher();
        }

        public void RegistrarParticipacion(Cliente cliente, Voucher voucher)
        {
            try
            {
                if (cliente.Id != 0)
                {
                    _negocioCliente.Actualizar(cliente);
                }
                else
                {
                    // guardar e id devuelto al objeto cliente de voucher
                    voucher.Cliente.Id = _negocioCliente.Registrar(cliente);
                }
                _negocioVoucher.RegistrarVoucherCliente(voucher);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
