using System;

namespace Common.Domain.ValueObjects
{
    /// <summary>Идентификатор сущности</summary>
    /// <typeparam name="T">Тип Сущности</typeparam>
    public record Id<T>
    {
        private readonly Guid _guid;

        private Id(Guid guid)
        {
            _guid = guid;
        }

        /// <summary>Создание нового идентификатора сущности</summary>
        /// <returns><see cref="Id{T}"/></returns>
        public static Id<T> New()
        {
            return new Id<T>(Guid.NewGuid());
        }

        /// <summary>Создание нового идентификатора сущности</summary>
        /// <param name="guid"><see cref="Guid"/></param>
        /// <returns><see cref="Id{T}"/></returns>
        public static Id<T> New(Guid guid)
        {
            return new Id<T>(guid);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _guid.ToString();
        }
    }
}