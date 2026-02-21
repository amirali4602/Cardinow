using AutoMapper;
using Cardinow.Application.Dtos.Profiles;
using Cardinow.Application.IServices;
using Cardinow.Domain.IRepositories;
using Profile = Cardinow.Domain.Entities.Profile;

namespace Cardinow.Application.Services;

public class ProfileService : IProfileService
{
    private readonly IGenericRepository<Profile> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfileService(IGenericRepository<Profile> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProfileReadDto?> GetByUserIdAsync(Guid userId)
    {
        var profile = (await _repository.GetAllAsync()).FirstOrDefault(p => p.UserId == userId);
        return profile == null ? null : _mapper.Map<ProfileReadDto>(profile);
    }

    public async Task UpdateAsync(Guid userId, UpdateProfileDto dto)
    {
        var profile = (await _repository.GetAllAsync()).FirstOrDefault(p => p.UserId == userId);
        if (profile == null) throw new Exception("Profile not found");

        _mapper.Map(dto, profile);
        profile.UpdatedAt = DateTime.UtcNow;

        _repository.Update(profile);
        await _unitOfWork.SaveChangesAsync();
    }
}