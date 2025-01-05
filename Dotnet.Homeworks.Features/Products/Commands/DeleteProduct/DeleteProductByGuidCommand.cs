using ICommand = Dotnet.Homeworks.Infrastructure.Cqrs.Commands.ICommand;

namespace Dotnet.Homeworks.Features.Products.Commands.DeleteProduct;

public class DeleteProductByGuidCommand(Guid guid) : ICommand
{
    public Guid Guid { get; init; } = guid;
}