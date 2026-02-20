using Cardinow.Application.Dtos.Users;
using FluentValidation;

namespace Cardinow.Application.Validators.User;

public class UpdateUserRoleDtoValidator
: AbstractValidator<UpdateUserRoleDto>
{
    public UpdateUserRoleDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Role)
            .IsInEnum();
    }
}
