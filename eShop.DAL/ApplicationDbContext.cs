using eShop.CORE;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL
{

    /// <summary>
    /// Contexto de datos
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Metodo estatico para crear el contexto
        /// </summary>
        /// <returns>Contexto de datos</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Coleccion persistible de productos
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Coleccion persistible de pedidos
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Coleccion persistible de lineas de pedido
        /// </summary>
        public DbSet<OrderLine> OrderLines { get; set; }

    }

}
