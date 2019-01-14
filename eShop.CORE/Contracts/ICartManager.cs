using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CORE.Contracts
{

    public interface ICartManager : IGenericManager<Cart>
    {
        IQueryable<Cart> GetCarritoByUsuarioId(string clientId);
        IQueryable<Cart> GetCarritoBySesionId(string sesionId);
    }
}
