using System.Linq;
using eShop.CORE;

namespace eShop.CORE.Contracts
{
    public interface IProductManager : IGenericManager<Product>
    {
        IQueryable<OrderLine> GetOrderLinesWithProductsByPedidoId(int orderId);
    }
}