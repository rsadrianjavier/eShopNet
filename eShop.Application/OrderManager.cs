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
    /// Clase manager de Order
    /// </summary>
    class OrderManager : GenericManager<Order>
    {
        /// <summary>
        /// Constructor de la clase Manager de Order
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public OrderManager(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Metodo que retorna todos los pedidos de un usuario
        /// </summary>
        /// <param name="userId">Identificador de usuario</param>
        /// <returns>Todos los pedidos del usuario</returns>
        public IQueryable<Order> GetByUserId(string userId)
        {
            return Context.Orders.Where(e => e.ClientId == userId);
        }

        /// <summary>
        /// Metodo que retorna todas las lineas de pedido de un pedido
        /// </summary>
        /// <param name="userId">Identificador del pedido</param>
        /// <returns>Todas las lineas de pedido de un pedido</returns>
        public IQueryable<OrderLine> GetOrderLinesByPedidoId(int orderId)
        {
            return Context.OrderLines.Where(e => e.OrderId == orderId);
        }

        /// <summary>
        /// Obtiene un pedido con sus lineas de pedido
        /// </summary>
        /// <param name="id">Identificador del pedido</param>
        /// <returns>Pedido con sus lineas si existe o null en caso de no existir</returns>
        public Order GetByIdWithOrderLines(int id)
        {
            return Context.Orders.Include("OrderLines").Where(i => i.OrderId == id).SingleOrDefault();
        }
    }
}
