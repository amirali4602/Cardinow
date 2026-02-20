using Cardinow.Application.Dtos.Profiles;
using FluentValidation;

namespace Cardinow.Application.Validators.Profile;

public class UpdateProfileDtoValidator : AbstractValidator<UpdateProfileDto>
{
    public UpdateProfileDtoValidator()
    {
        RuleFor(x => x.LinksJson)
            .NotEmpty().WithMessage("Links cant be Empty");

        RuleFor(x => x.BannerUrl)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.BannerUrl));

        RuleFor(x => x.LogoUrl)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.LogoUrl));

        RuleFor(x => x.VcfLink)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.VcfLink));
    }
}