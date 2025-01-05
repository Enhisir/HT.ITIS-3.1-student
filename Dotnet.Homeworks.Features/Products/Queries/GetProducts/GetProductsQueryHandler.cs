using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Features.Products.Commands.DeleteProduct;
using Dotnet.Homeworks.Infrastructure.Cqrs.Queries;
using Dotnet.Homeworks.Shared.Dto;
using Microsoft.Extensions.Logging;

namespace Dotnet.Homeworks.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler(
    IProductRepository productRepository)
    : IQueryHandler<GetProductsQuery, GetProductsDto>
{
    public async Task<Result<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var list = 
            (await productRepository.GetAllProductsAsync(cancellationToken))
            .Select(x => new GetProductDto(x.Id, x.Name));
        return new Result<GetProductsDto>(new GetProductsDto(list), true);
    }
}