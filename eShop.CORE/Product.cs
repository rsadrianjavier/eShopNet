using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Entidad de dominio de productos
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public Double Price { get; set; }

        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Colección de Documentos del producto, imágenes, videos, etc
        /// </summary>
        public virtual List<Document> Documents { get; set; }

        /// <summary>
        /// Número de unidades del producto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Indica si el producto está disponible
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Indica si el producto está disponible
        /// </summary>
        public Byte[] Image { get; set; }
    }
}
