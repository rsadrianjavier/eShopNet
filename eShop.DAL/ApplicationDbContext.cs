using eShop.CORE;
using eShop.CORE.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace eShop.DAL
{
    //Enable-Migrations
    //Add-Migration "name xxxxx" -StartUpProjectName "eShop.Web" -ConnectionStringName "DefaultConnection" -Verbose
    //Update-Database -StartUpProjectName "eShop.Web" -ConnectionStringName "DefaultConnection" -Verbose 

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
        /// Colección persistible de carrito de compra
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Colección persistible de direcciones
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Colección persistible de documentos
        /// </summary>
        public DbSet<Document> Documents { get; set; }
    }

}
