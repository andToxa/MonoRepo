using Common.Domain.Entities.Abstractions;
using Common.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Common.Domain.Services;

/// <summary>
/// Репозиторий агрегатов
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Восстановление состояния
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <returns><see cref="IEntity{T}"/></returns>
    public Task<IEntity<T>> LoadAsync(Id<T> id);

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    /// <param name="entity"><see cref="IEntity{T}"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    public Task SaveAsync(IEntity<T> entity);
}
