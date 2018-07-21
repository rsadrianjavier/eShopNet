using eShop.CORE;
using eShop.CORE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application
{
    public class CartManager : GenericManager<Cart>, ICartManager
    {
        public CartManager(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}
