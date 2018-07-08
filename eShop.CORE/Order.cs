﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Entidad de dominio de pedidos
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Fecha del pedido
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Cliente que hace el pedido
        /// </summary>
        public ApplicationUser Client { get; set; }

        /// <summary>
        /// Identificador del cliente que hace el pedido
        /// </summary>
        [ForeignKey("Client")]
        public string ClientId { get; set; }

        /// <summary>
        /// Coleccion de lineas de pedido
        /// </summary>
        public virtual List<OrderLine> OrderLines { get; set; }
        //virtual indica que es otra entidad
    }
}