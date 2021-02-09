using MediatR;

namespace Application.CQRS.Queries
{
    /// <summary>Пример запроса</summary>
    public class ExampleQuery : IRequest<ExampleQueryResult>
    {
    }
}