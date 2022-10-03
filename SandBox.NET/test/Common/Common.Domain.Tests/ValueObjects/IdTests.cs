using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using System;
using System.Text.Json;
using Xunit;

namespace Common.Domain.Tests.ValueObjects
{
    /// <summary>Тесты <see cref="Id{T}"/></summary>
    public class IdTests
    {
        /// <summary>Тест создания <see cref="Id{T}"/></summary>
        [Fact]
        public void IdNewEqualTest()
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
        public void IdNewNotEqualTest()
        {
            var id1 = Id<IEntity<object>>.New();
            var id2 = Id<IEntity<object>>.New();
            Assert.NotEqual(id1, id2);
        }

        /// <summary>
        /// Тестирование сериализации <see cref="IdJsonConverterFactory"/>
        /// </summary>
        [Fact]
        public void IdJsonSerializationTest()
        {
            var guid = Guid.NewGuid();
            var id1 = Id<IEntity<object>>.New(guid);

            Assert.Equal($"\"{id1}\"", JsonSerializer.Serialize(id1));
        }

        /// <summary>
        /// Тестирование десериализации <see cref="IdJsonConverterFactory"/>
        /// </summary>
        [Fact]
        public void IdJsonDeserializationTest()
        {
            var guid = Guid.NewGuid();
            var id1 = Id<IEntity<object>>.New(guid);
            var id2 = JsonSerializer.Deserialize<Id<IEntity<object>>>($"\"{id1}\"");

            Assert.Equal(id1, id2);
        }
    }
}