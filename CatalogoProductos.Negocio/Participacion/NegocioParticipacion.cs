using CatalogoProductos.Dominio.Entidades;
using CatalogoProductos.Negocio.Clientes;
using CatalogoProductos.Servicios.Email;
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

                EnviarCorreoConfirmacion(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EnviarCorreoConfirmacion(Cliente cliente)
        {
            try
            {
                ServicioEmail servicioEmail = new ServicioEmail();

                Dictionary<string, string> valoresAReemplazar = new Dictionary<string, string>
                {
                    {"Nombre", cliente.Nombre }
                };

                string htmlPlantilla = @"<!DOCTYPE html>
                            <html lang=""es"">
                            <head>
                                <meta charset=""UTF-8"">
                                <title>Confirmación de Participación</title>
                                <style>
                                    body {
                                        font-family: Arial, sans-serif;
                                        background-color: #f4f4f4;
                                        margin: 0;
                                        padding: 0;
                                    }

                                    .container {
                                        max-width: 600px;
                                        margin: 30px auto;
                                        background-color: #ffffff;
                                        padding: 25px;
                                        border-radius: 8px;
                                        box-shadow: 0 0 12px rgba(0,0,0,0.1);
                                    }

                                    .header {
                                        text-align: center;
                                        padding-bottom: 20px;
                                    }

                                        .header h1 {
                                            color: #4CAF50;
                                            font-size: 28px;
                                            margin: 0;
                                        }

                                    .content {
                                        font-size: 16px;
                                        line-height: 1.6;
                                        color: #333333;
                                    }

                                    .highlight {
                                        color: #4CAF50;
                                        font-weight: bold;
                                    }

                                    .footer {
                                        margin-top: 30px;
                                        font-size: 12px;
                                        color: #999999;
                                        text-align: center;
                                    }

                                    @media only screen and (max-width: 600px) {
                                        .container {
                                            padding: 15px;
                                        }

                                        .header h1 {
                                            font-size: 24px;
                                        }
                                    }
                                </style>
                            </head>
                            <body>
                                <div class=""container"">
                                    <div class=""header"">
                                        <h1>¡Hola {Nombre}!</h1>
                                    </div>

                                    <div class=""content"">
                                        <p>Gracias por registrarte en nuestra <span class=""highlight"">Promoción Web 2025</span>.</p>
                                        <p>Tu registro se ha realizado correctamente y ahora estás participando para ganar.</p>
                                        <p>¡Mucha suerte en la promoción!</p>
                                    </div>

                                    <div class=""footer"">
                                        <p>TUP Programación III - Equipo 9C</p>
                                    </div>
                                </div>
                            </body>
                            </html>
                            ";
                htmlPlantilla = htmlPlantilla.Replace("{Nombre}", cliente.Nombre);
                bool enviado = servicioEmail.Enviar(cliente.Email, "¡Confirmación de participación en la promoción web!", htmlPlantilla, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
