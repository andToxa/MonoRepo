using MediatR;

namespace Application.ExampleContext.Queries
{
    /// <summary>Пример запроса</summary>
    public class ExampleQuery : IRequest<ExampleQueryResult>
    {
    }
}