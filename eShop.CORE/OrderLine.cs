using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Entidad de dominio de lineas de pedido
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Identificador de la linea de pedido
        /// </summary>
        [Key]
        public int OrderLineId { get; set; }

        /// <summary>
        /// Pedido al que pertenece la linea
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Identificador del pedido al que pertenece la linea
        /// </summary>
        [ForeignKey("Order")]
        public int OrderId { get; set; }


        /// <summary>
        /// Producto de la linea
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identificador del producto de la linea
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad de productos de la linea
        /// </summary>
        public int Quantity { get; set; }

    }
}
