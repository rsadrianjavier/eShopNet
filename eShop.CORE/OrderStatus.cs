using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE
{
    /// <summary>
    /// Enumerado con los estados de pedido
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// El pedido está realizado pero todavía no tratado
        /// </summary>
        Pending,
        /// <summary>
        /// El pedido se ha pagado
        /// </summary>
        Paid,
        /// <summary>
        /// El pedido se está preparando
        /// </summary>
        InProccess,
        /// <summary>
        /// El pedido ha sido enviado
        /// </summary>
        Sent,
        /// <summary>
        /// El pedido ha sido entregado
        /// </summary>
        Delivered
    }
}
