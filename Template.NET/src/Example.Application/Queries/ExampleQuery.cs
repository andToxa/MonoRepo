using MediatR;

namespace Example.Application.Queries
{
    /// <summary>Пример запроса</summary>
    public class ExampleQuery : IRequest<ExampleQueryResult>
    {
    }
}