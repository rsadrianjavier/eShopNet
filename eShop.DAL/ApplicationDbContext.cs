using eShop.CORE;
using eShop.CORE.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace eShop.DAL
{

    /// <summary>
    /// Clase de contexto de datos de Entity Framework
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
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

        /// <summary>
        /// Coleccion persistible de usuarios
        /// </summary>
        public DbSet<IdentityUser> AspNetUsers { get; set; }

        /// <summary>
        /// Coleccion persistible de roles
        /// </summary>
        public DbSet<IdentityRole> AspNetRoles { get; set; }

        /// <summary>
        /// Coleccion persistible de roles de usuario
        /// </summary>
        public DbSet<IdentityUserRole> AspNetUserRoles { get; set; }

    }

}
