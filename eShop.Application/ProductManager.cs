using eShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DAL;

namespace eShop.Application
{
    /// <summary>
    /// Manager de Product
    /// </summary>
    public class ProductManager : GenericManager<Product>
    {
        /// <summary>
        /// Constructor del manager de Product
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public ProductManager(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todas las lineas con sus productos de un pedido
        /// </summary>
        /// <param name="userId">Identificador del pedido</param>
        /// <returns>Todas las lineas con sus productos de un pedido</returns>
        public IQueryable<OrderLine> GetOrderLinesWithProductsByPedidoId(int orderId)
        {
            return Context.OrderLines.Include("Product").Where(e => e.OrderId == orderId);
        }

    }
}
