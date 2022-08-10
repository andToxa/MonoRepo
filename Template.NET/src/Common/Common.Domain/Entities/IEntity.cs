using Common.Domain.ValueObjects;

namespace Common.Domain.Entities
{
    /// <summary>Доменная сущность</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IEntity<T>
    {
        /// <summary>Идентификатор сущности</summary>
        public Id<T> Id { get; }
    }
}