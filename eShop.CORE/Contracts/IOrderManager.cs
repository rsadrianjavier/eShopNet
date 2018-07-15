using System.Linq;
using eShop.CORE;

namespace eShop.CORE.Contracts
{
    public interface IOrderManager : IGenericManager<Order>
    {
        Order GetByIdWithOrderLines(int id);
        IQueryable<Order> GetByUserId(string userId);
        IQueryable<OrderLine> GetOrderLinesByPedidoId(int orderId);
    }
}