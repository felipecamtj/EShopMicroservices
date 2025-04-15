using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() =>
    [
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its ...",
            ImageFile = "product1.png",
            Price = 950.00M,
            Category = ["Smart Phone"]
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Sansung 10",
            Description = "This phone is the company's biggest change to its ...",
            ImageFile = "product2.png",
            Price = 840.00M,
            Category = ["Smart Phone"]
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Panasonic Lumix",
            Description = "This phone is the company's biggest change to its ...",
            ImageFile = "product3.png",
            Price = 240.00M,
            Category = ["Camera"]
        }
    ];
}
