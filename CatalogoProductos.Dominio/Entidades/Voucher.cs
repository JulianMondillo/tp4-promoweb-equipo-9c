using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Dominio.Entidades
{
    public class Voucher
    {
        public string Codigo { get; set; }
        public DateTime? FechaCanje { get; set; }
        public Cliente Cliente { get; set; }
        public Articulo Articulo { get; set; }
    }
}
