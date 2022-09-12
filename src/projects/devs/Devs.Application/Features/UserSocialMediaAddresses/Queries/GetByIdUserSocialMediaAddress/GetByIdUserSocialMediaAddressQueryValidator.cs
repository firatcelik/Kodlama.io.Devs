using FluentValidation;
using Devs.Application.Features.UserSocialMediaAddresses.Constants;

namespace Devs.Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;

/// <summary>
/// 
/// </summary>
public class GetByIdUserSocialMediaAddressQueryValidator : AbstractValidator<GetByIdUserSocialMediaAddressQuery>
{
    public GetByIdUserSocialMediaAddressQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(UserSocialMediaAddressMessages.IdIsRequired);

        RuleFor(p => p.Id)
            .GreaterThan(0).WithMessage(UserSocialMediaAddressMessages.GreaterThanZero);
    }
}