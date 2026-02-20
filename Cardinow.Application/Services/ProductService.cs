using AutoMapper;
using Cardinow.Application.Dtos.Products;
using Cardinow.Application.IServices;
using Cardinow.Domain.Entities;
using Cardinow.Domain.IRepositories;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ProductReadDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductReadDto>>(products);
    }

    public async Task<ProductReadDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product == null ? null : _mapper.Map<ProductReadDto>(product);
    }

    public async Task CreateAsync(CreateProductDto dto)
    {
        var entity = _mapper.Map<Product>(dto);

        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return;

        _mapper.Map(dto, entity);

        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return;

        entity.IsDeleted = true; // SoftDelete
        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync();
    }
}