using System.Threading.Tasks;

namespace Domain.Common
{
    /// <summary>Шина доменных событий</summary>
    public interface IEventBus
    {
        /// <summary>Публикация доменного события</summary>
        /// <param name="domainEvent">Данные доменного события</param>
        /// <typeparam name="T">Тип доменного события</typeparam>
        /// <returns><see cref="Task"/></returns>
        public Task PublishAsync<T>(T domainEvent);
    }
}