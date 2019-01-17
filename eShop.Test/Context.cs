using eShop.CORE;
using eShop.CORE.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace eShop.Test
{
    public class Context : IApplicationDbContext
    {

        private Mock<IApplicationDbContext> context = null;
        private List<Order> OrderList = new List<Order>();
        private List<Product> ProductList = new List<Product>();
        public Context()
        {
            context = new Mock<IApplicationDbContext>();
            var mockCategory = CreateMock<Order>(OrderList);
            context.Setup(m => m.Set<Order>()).Returns(mockCategory.Object);

            var mockProduct = CreateMock<Product>(ProductList);
            context.Setup(m => m.Set<Product>()).Returns(mockProduct.Object);

            context.Setup(m => m.SaveChanges()).Returns(0);
        }
        public System.Data.Entity.DbSet<T> Set<T>() where T : class
        {
            return context.Object.Set<T>();
        }

        public IApplicationDbContext Create()
        {
            return this;
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return context.Object.Entry<T>(entity);
        }

        public int SaveChanges()
        {
            return context.Object.SaveChanges();
        }

        public Mock<DbSet<T>> CreateMock<T>(List<T> list)
            where T : class
        {
            var result = new Mock<DbSet<T>>();
            result.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.AsQueryable().Provider);
            result.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.AsQueryable().Expression);
            result.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.AsQueryable().ElementType);
            result.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            result.Setup(x => x.AsNoTracking()).Returns(result.Object);
            result.Setup(x => x.Add(It.IsAny<T>())).Callback<T>((s) => list.Add(s));
            result.Setup(x => x.Remove(It.IsAny<T>())).Callback<T>((s) => list.Remove(s));
            return result;
        }
    }
}
