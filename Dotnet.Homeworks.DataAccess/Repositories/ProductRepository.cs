using Dotnet.Homeworks.Data.DatabaseContext;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Homeworks.DataAccess.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        => await dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);

    public async Task DeleteProductByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = 
            await dbContext.Products
                .Where(x => x.Id.Equals(id))
                .SingleOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Product(id={id}) not found");

        dbContext.Products.Remove(product);
    }

    public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        => await Task.FromResult(dbContext.Products.Update(product));

    public async Task<Guid> InsertProductAsync(Product product, CancellationToken cancellationToken)
        => await Task.FromResult(dbContext.Products.Add(product).Entity.Id);
}