using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Common.Domain.Tests.Entities
{
    /// <inheritdoc />
    public class TestEntity : IEntity<TestEntity>
    {
        /// <summary>Initializes a new instance of the <see cref="TestEntity"/> class.</summary>
        /// <param name="id"><see cref="EntityId{T}"/></param>
        public TestEntity(EntityId<TestEntity> id)
        {
            Id = id;
        }

        /// <inheritdoc />
        public EntityId<TestEntity> Id { get; }
    }
}