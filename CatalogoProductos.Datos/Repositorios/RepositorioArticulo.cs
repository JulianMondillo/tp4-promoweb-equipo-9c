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
        public void GuardarImagenes(int idArticulo, List<string> urls)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (string url in urls)
                {
                    datos.DefinirConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                    datos.setearParametro("@IdArticulo", idArticulo);
                    datos.setearParametro("@ImagenUrl", url);
                    datos.EjecutarAccion();

                    datos.LimpiarParametros(); // limpio para la próxima vuelta
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Articulo> Listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader lector;

            try
            {
                datos.DefinirConsulta(@"
            SELECT a.Id, a.Nombre, a.Descripcion,
                   img.ImagenId, img.ImagenUrl
            FROM ARTICULOS a
            OUTER APPLY (
                SELECT TOP 1 i.Id AS ImagenId, i.ImagenUrl
                FROM IMAGENES i
                WHERE i.IdArticulo = a.Id
                ORDER BY i.Id
            ) img
            ORDER BY a.Id;
        ");

                datos.EjecutarConsulta();
                lector = datos.Lector;

                while (lector.Read())
                {
                    Articulo nuevoArticulo = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = lector["Descripcion"] as string,
                        Imagenes = new List<Imagen>()
                    };

                    if (lector["ImagenUrl"] != DBNull.Value)
                    {
                        Imagen img = new Imagen
                        {
                            Id = lector["ImagenId"] != DBNull.Value ? (int)lector["ImagenId"] : 0,
                            Url = (string)lector["ImagenUrl"]
                        };
                        nuevoArticulo.Imagenes.Add(img);
                    }

                    articulos.Add(nuevoArticulo);
                }

                return articulos;
            }
            catch
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