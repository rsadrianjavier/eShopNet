using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using eShop.CORE;

namespace eShop.CORE.Contracts
{
    /// <summary>
    /// Interfaz del contexto
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<OrderLine> OrderLines { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Guarda cambios en el contexto
        /// </summary>
        /// <returns>Número de elementos guardados</returns>
        int SaveChanges();

        DbEntityEntry Entry(object entity);

        /// <summary>
        /// Obtiene una entrada de una entidad del contexto
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad que queremos la entrada</typeparam>
        /// <param name="entity">Entidad de la que queremos su entrada</param>
        /// <returns>Entrada de la entidad</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet Set(Type entityType);

        /// <summary>
        /// Obtiene la colección de una entidad
        /// </summary>
        /// <typeparam name="TEntity">Entidad de la que queremos el contexto</typeparam>
        /// <returns>Colección de la entidad</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}