using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Infrastructure.Cqrs.Commands;
using Dotnet.Homeworks.Infrastructure.UnitOfWork;
using Dotnet.Homeworks.Shared.Dto;
using Microsoft.Extensions.Logging;

namespace Dotnet.Homeworks.Features.Products.Commands.DeleteProduct;

internal sealed class DeleteProductByGuidCommandHandler (
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteProductByGuidCommand>
{
    public async Task<Result> Handle(DeleteProductByGuidCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            await productRepository.DeleteProductByGuidAsync(command.Guid, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new Result(true);
        }
        catch (Exception e)
        {
            return new Result(false, e.Message);
        }
    }
}