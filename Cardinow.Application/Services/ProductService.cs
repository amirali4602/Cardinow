using AutoMapper;
using Cardinow.Application.Dtos.Products;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductReadDto>>(products);
    }

    public async Task<ProductReadDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product == null ? null : _mapper.Map<ProductReadDto>(product);
    }

    public async Task CreateAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        product.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) throw new Exception("Product not found");

        _mapper.Map(dto, product);
        product.UpdatedAt = DateTime.UtcNow;

        _repository.Update(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) throw new Exception("Product not found");

        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow;

        _repository.Update(product);
        await _unitOfWork.SaveChangesAsync();
    }
}