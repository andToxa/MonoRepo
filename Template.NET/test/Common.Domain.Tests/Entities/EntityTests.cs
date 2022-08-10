using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Xunit;

namespace Common.Domain.Tests.Entities
{
    /// <summary>Тесты <see cref="IEntity{T}"/></summary>
    public class EntityTests
    {
        /// <summary>
        /// test
        /// </summary>
        [Fact]
        public void Test1()
        {
            var entityOne = new TestEntity(Id<TestEntity>.New());
            var entityTwo = new TestEntity(Id<TestEntity>.New());
            Assert.NotEqual(entityOne.Id, entityTwo.Id);
        }
    }
}