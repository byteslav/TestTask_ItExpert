using MediatR;

namespace TestTask.Application.Handlers.Commands
{
    public sealed record CreateProductCommand(
        IEnumerable<Dictionary<int, string>> Data) : IRequest;
}
