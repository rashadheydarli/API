using System;
using Business.DTOs.Auth.Request;
using FluentValidation;

namespace Business.Validators.Auth
{
	public class AuthLoginDTOValidator : AbstractValidator<AuthLoginDTO>
	{
		public AuthLoginDTOValidator()
		{
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Poçt ünvanı daxil edilməlidir");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifrə daxil edilməlidir");
        }
	}
}

