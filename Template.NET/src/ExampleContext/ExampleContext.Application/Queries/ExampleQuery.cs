using MediatR;

namespace ExampleContext.Application.Queries
{
    /// <summary>Пример запроса</summary>
    public class ExampleQuery : IRequest<ExampleQueryResult>
    {
    }
}