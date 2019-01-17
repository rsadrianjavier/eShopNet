using System;
using eShop.Application;
using eShop.CORE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eShop.Test
{
    [TestClass]
    public class OrderManagerTest
    {
        [TestMethod]
        public void GetByUserIdTest()
        {
            // Arrange
            Context context = new Context();
            OrderManager manager = new OrderManager(context);
            Order order = new Order();

            // Act
            manager.GetByUserId();

            // 


        }
    }
}
