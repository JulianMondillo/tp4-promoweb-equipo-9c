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
                    SELECT AR.Id, AR.Nombre, AR.Descripcion, 
                            IM.Id AS IdImagen, IM.ImagenUrl, CAT.Descripcion AS Categoria, MARC.Descripcion AS Marca
                    FROM ARTICULOS AR
                    JOIN IMAGENES IM ON AR.Id = IM.IdArticulo
                    JOIN CATEGORIAS CAT ON AR.IdCategoria = CAT.Id
                    JOIN MARCAS MARC ON AR.IdMarca = MARC.Id
                ");

                datos.EjecutarConsulta();
                lector = datos.Lector;
                Articulo articuloActual = null;

                while (lector.Read())
                {
                    int? idArticulo = (int)lector["Id"];

                    // si no hay un articulo actual o si hay uno, pero el id que leemos es distinto al articuloActual
                    // entonces significa que debemos crear el objeto del artículo
                    if (articuloActual == null || (articuloActual.Id != idArticulo))
                    {
                        articuloActual = new Articulo
                        {
                            Id = (int)lector["Id"],
                            Nombre = (string)lector["Nombre"],
                            Descripcion = lector["Descripcion"] as string,
                            Categoria = new Categoria { Descripcion = (string)lector["Categoria"] },
                            Marca = new Marca { Descripcion = (string)lector["Marca"] },
                            Imagenes = new List<Imagen>()
                        };

                        articulos.Add(articuloActual);
                    }


                    // si no entra a la condición anterior, entonces vamos a agregarle las imágenes a la lista del aticuloActual sin crear otro objeto
                    if (lector["ImagenUrl"] != DBNull.Value)
                    {
                        Imagen img = new Imagen
                        {
                            Id = (int)lector["IdImagen"],
                            Url = (string)lector["ImagenUrl"]
                        };
                        articuloActual.Imagenes.Add(img);
                    }
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