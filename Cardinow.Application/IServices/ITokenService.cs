using Cardinow.Domain.Entities;

namespace Cardinow.Application.IServices;

public interface ITokenService
{
    string GenerateToken(User user);
}
