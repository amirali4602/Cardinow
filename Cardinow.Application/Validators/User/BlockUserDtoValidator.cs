using Cardinow.Application.Dtos.Users;
using FluentValidation;

namespace Cardinow.Application.Validators.User;

public class BlockUserDtoValidator
: AbstractValidator<BlockUserDto>
{
    public BlockUserDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Invalid ID");
    }
}
