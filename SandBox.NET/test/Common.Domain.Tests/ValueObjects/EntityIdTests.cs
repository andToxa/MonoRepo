using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using System;
using Xunit;

namespace Common.Domain.Tests.ValueObjects
{
    /// <summary>Тесты <see cref="Id{T}"/></summary>
    public class EntityIdTests
    {
        /// <summary>Тест создания <see cref="Id{T}"/></summary>
        [Fact]
        public void EntityIdNewEqualTest()
        {
            var guid = Guid.NewGuid();
            var id1 = Id<IEntity<object>>.New(guid);
            var id2 = Id<IEntity<object>>.New(guid);
            Assert.Equal(guid.ToString(), id1.ToString());
            Assert.Equal(guid.ToString(), id2.ToString());
            Assert.Equal(id1, id2);
        }

        /// <summary>Тест создания новых <see cref="Id{T}"/></summary>
        [Fact]
        public void EntityIdNewNotEqualTest()
        {
            var id1 = Id<IEntity<object>>.New();
            var id2 = Id<IEntity<object>>.New();
            Assert.NotEqual(id1, id2);
        }
    }
}