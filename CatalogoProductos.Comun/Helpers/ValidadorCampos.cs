using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Comun
{
    public static class ValidadorCampos
    {
        public static bool EsTextoObligatorio(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }

        public static bool EsAlfanumerico(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool TieneLongitudMinima(string texto, int minimo)
        {
            return texto?.Trim().Length >= minimo;
        }

        public static bool TieneLongitudMaxima(string texto, int maximo)
        {
            return texto?.Trim().Length <= maximo;
        }

        public static string NormalizarTexto(string texto)
        {
            return texto?.Trim().ToUpper();
        }

        public static bool EsTextoValido(string texto, int minimo, int maximo)
        {
            return EsTextoObligatorio(texto)
                && TieneLongitudMinima(texto, minimo)
                && TieneLongitudMaxima(texto, maximo);
        }

    }
}
