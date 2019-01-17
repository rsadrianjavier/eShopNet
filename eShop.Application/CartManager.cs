using eShop.CORE;
using eShop.CORE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application
{
    /// <summary>
    /// Clase manager de Cart
    /// </summary>
    public class CartManager : GenericManager<Cart>, ICartManager
    {
        /// <summary>
        /// Constructor de la clase Manager de Cart
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public CartManager(IApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Metodo que retorna todos los pedidos de un usuario
        /// </summary>
        /// <param name="clientId">Identificador de cliente</param>
        /// <returns>Todas las lineas del carrito del cliente</returns>
        public IQueryable<Cart> GetCarritoByUsuarioId(string clientId)
        {
            return Context.Carts.Where(e => e.Client_Id == clientId);
        }

        /// <summary>
        /// Metodo que retorna todos los pedidos de un usuario
        /// </summary>
        /// <param name="sesionId">Identificador de sesion</param>
        /// <returns>odas las lineas del carrito de la sesion</returns>
        public IQueryable<Cart> GetCarritoBySesionId(string sesionId)
        {
            return Context.Carts.Where(e => e.SessionId == sesionId);
        }
    }
}
