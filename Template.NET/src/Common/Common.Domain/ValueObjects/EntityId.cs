using System;

namespace Common.Domain.ValueObjects
{
    /// <summary>Идентификатор сущности</summary>
    /// <typeparam name="T">Тип Сущности</typeparam>
    public record EntityId<T>
    {
        private Guid _guid;

        private EntityId(Guid guid)
        {
            _guid = guid;
        }

        /// <summary>Создание нового идентификатора сущности</summary>
        /// <returns><see cref="EntityId{T}"/></returns>
        public static EntityId<T> New()
        {
            return new EntityId<T>(Guid.NewGuid());
        }

        /// <summary>Создание нового идентификатора сущности</summary>
        /// <param name="guid"><see cref="Guid"/></param>
        /// <returns><see cref="EntityId{T}"/></returns>
        public static EntityId<T> New(Guid guid)
        {
            return new EntityId<T>(guid);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _guid.ToString();
        }
    }
}