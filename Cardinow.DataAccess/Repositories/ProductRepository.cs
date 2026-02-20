using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

namespace Cardinow.DataAccess.Repositories;


public class ProductRepository
    : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context)
        : base(context)
    {
    }
}