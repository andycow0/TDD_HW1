using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.HW1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using ExpectedObjects.Comparisons;
namespace TDD.HW1.Tests
{
    [TestClass()]
    public class OrderAnalyzerTests
    {
        private IEnumerable<Order> orders = GetOrderList();
        [TestMethod()]
        public void GetSumByCostTest()
        {
            // arrange
            var anallyzer = new OrderAnalyzer<Order>(orders);
            //var fieldName = nameof(Order.Cost);
            var expected = (new[] { 6, 15, 24, 21 }).ToList();
            // act
            var actual = anallyzer.GetSumByCost(3, "Cost");

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GetSumByRevenueTest()
        {
            // arrange
            var anallyzer = new OrderAnalyzer<Order>(orders);
            //var fieldName = nameof(Order.Cost);
            var expected = (new[] { 50, 66, 60 }).ToList();
            // act
            var actual = anallyzer.GetSumByCost(4, "Revenue");

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private static List<Order> GetOrderList()
        {
            return new List<Order>()
            {
                new Order() { Id=1,  Cost=1,  Revenue=11,  SellPrice=21 },
                new Order() { Id=2,  Cost=2,  Revenue=12,  SellPrice=22 },
                new Order() { Id=3,  Cost=3,  Revenue=13,  SellPrice=23 },
                new Order() { Id=4,  Cost=4,  Revenue=14,  SellPrice=24 },
                new Order() { Id=5,  Cost=5,  Revenue=15,  SellPrice=25 },
                new Order() { Id=6,  Cost=6,  Revenue=16,  SellPrice=26 },
                new Order() { Id=7,  Cost=7,  Revenue=17,  SellPrice=27 },
                new Order() { Id=8,  Cost=8,  Revenue=18,  SellPrice=28 },
                new Order() { Id=9,  Cost=9,  Revenue=19,  SellPrice=29 },
                new Order() { Id=10, Cost=10, Revenue=20, SellPrice=30 },
                new Order() { Id=11, Cost=11, Revenue=21, SellPrice=31 },
            };
        }
    }
    public class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }
}