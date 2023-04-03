using Common.Domain.Entities.Abstractions;
using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Converters;
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
            var id1 = new Id<IEntity<object>>(guid);
            var id2 = new Id<IEntity<object>>(guid);
            Assert.Equal(guid.ToString(), id1.ToString());
            Assert.Equal(guid.ToString(), id2.ToString());
            Assert.Equal(id1, id2);
        }

        /// <summary>Тест создания новых <see cref="Id{T}"/></summary>
        [Fact]
        public void IdNewNotEqualTest()
        {
            var id1 = new Id<IEntity<object>>();
            var id2 = new Id<IEntity<object>>();
            Assert.NotEqual(id1, id2);
        }

        /// <summary>
        /// Тестирование сериализации <see cref="IdJsonConverterFactory"/>
        /// </summary>
        [Fact]
        public void IdJsonSerializationTest()
        {
            var guid = Guid.NewGuid();
            var id1 = new Id<IEntity<object>>(guid);

            Assert.Equal(JsonSerializer.Serialize(guid), JsonSerializer.Serialize(id1));
        }

        /// <summary>
        /// Тестирование десериализации <see cref="IdJsonConverterFactory"/>
        /// </summary>
        [Fact]
        public void IdJsonDeserializationTest()
        {
            var guid = Guid.NewGuid();
            var id1 = new Id<IEntity<object>>(guid);
            var id2 = JsonSerializer.Deserialize<Id<IEntity<object>>>(JsonSerializer.Serialize(guid));

            Assert.Equal(id1, id2);
        }
    }
}