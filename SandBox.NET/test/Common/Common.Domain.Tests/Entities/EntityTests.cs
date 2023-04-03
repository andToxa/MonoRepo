using Common.Domain.Entities.Abstractions;
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
            var entityOne = new TestEntity(new Id<TestEntity>());
            var entityTwo = new TestEntity(new Id<TestEntity>());
            Assert.NotEqual(entityOne.Id, entityTwo.Id);
        }
    }
}