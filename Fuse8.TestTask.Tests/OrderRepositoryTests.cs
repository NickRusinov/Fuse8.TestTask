using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fuse8.TestTask.Tests
{
    public class OrderRepositoryTests : IClassFixture<Fuse8ContextFixture>
    {
        private readonly Fuse8ContextFixture contextFixture;

        public OrderRepositoryTests(Fuse8ContextFixture contextFixture)
        {
            this.contextFixture = contextFixture;
        }

        [Theory]
        [InlineData(2010, 1, 1, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(2012, 3, 4, new[] { 3, 4, 5 })]
        [InlineData(2014, 6, 6, new int[0])]
        public void WithMinDateTest(int year, int month, int day, int[] idCollection)
        {
            var sut = new OrderRepository(contextFixture.Context.Orders);

            var items = sut.WithMinDate(new DateTime(year, month, day)).ToList();

            Assert.Equal(idCollection.Length, items.Count);
            Assert.Equal(idCollection.Length, items.Select(o => o.Id).Intersect(idCollection).Count());
        }

        [Theory]
        [InlineData(2014, 6, 6, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(2011, 2, 3, new[] { 1, 2 })]
        [InlineData(2010, 1, 1, new int[0])]
        public void WithMaxDateTest(int year, int month, int day, int[] idCollection)
        {
            var sut = new OrderRepository(contextFixture.Context.Orders);

            var items = sut.WithMaxDate(new DateTime(year, month, day)).ToList();

            Assert.Equal(idCollection.Length, items.Count);
            Assert.Equal(idCollection.Length, items.Select(o => o.Id).Intersect(idCollection).Count());
        }
    }
}
