using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoProductos.Datos.Repositorios;
using CatalogoProductos.Comun;

namespace CatalogoProductos.Negocio
{
    public class NegocioVoucher
    {

        private readonly RepositorioVoucher _repo;

        public NegocioVoucher()
        {
            _repo = new RepositorioVoucher();
        }

        public bool ValidarVoucher(string codigo)
        {
            if (!ValidadorCampos.EsTextoObligatorio(codigo))
                throw new ArgumentException("El código del voucher no puede estar vacío.");

            if (!ValidadorCampos.EsAlfanumerico(codigo))
                throw new ArgumentException("El código del voucher sólo puede contener letras y números.");

            return _repo.VoucherEsValido(codigo);
        }

    }
}
