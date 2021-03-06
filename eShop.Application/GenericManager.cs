﻿using eShop.CORE.Contracts;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application
{
    /// <summary>
    /// Clase genérica de acceso a datos de una entidad
    /// </summary>
    /// /// <typeparam name="T">Entidad de la que tenemos acceso con esta clase genérica</typeparam>
    public class GenericManager<T> : IGenericManager<T>
        where T : class
    {
        /// <summary>
        /// Contexto de datos del manager
        /// </summary>
        public IApplicationDbContext Context { get; private set; }

        /// <summary>
        /// Constructor del manager
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public GenericManager(IApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Añade una entidad al contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Elimina una entidad del contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>
        public T Remove(T entity)
        {
            return Context.Set<T>().Remove(entity);
        }


        /// <summary>
        /// Obtiene una entidad por sus posibles claves
        /// </summary>
        /// <param name="key">Claves del objeto</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        /// <summary>
        /// Obtiene una entidad por su clave int
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(int id)
        {
            return GetById(new object[] { id });
        }

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns>Entidad si es encontrada</returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
    }
}
