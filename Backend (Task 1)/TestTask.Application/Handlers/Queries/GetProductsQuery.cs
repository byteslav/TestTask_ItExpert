using MediatR;
using TestTask.Domain.Entities;

namespace TestTask.Application.Handlers.Queries
{
    public sealed record GetProductsQuery(
        int? Code,
        string? Value)
        : IRequest<IEnumerable<Product>>;
}
