using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Clase de dominio de carrito
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Identificador del carrito
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador de la sesión
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// Usuario actual dueño del carrito
        /// </summary>
        public ApplicationUser Client { get; set; }
        /// <summary>
        /// Identificador del Usuario actual dueño del carrito
        /// </summary>
        [ForeignKey("Client")]
        public string Client_Id { get; set; }
        /// <summary>
        /// Producto añadido al carrito
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Identificador del producto añadido al carrito
        /// </summary>
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        /// <summary>
        /// Cantidad añadida
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fecha hora de cuando se ha añadido el producto
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Precio neto del producto a la hora de añadirlo a la cesta
        /// </summary>
        public decimal NetPrice { get; set; }
    }
}
