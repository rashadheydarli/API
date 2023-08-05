using System;
using Business.DTOs.Auth.Request;
using FluentValidation;

namespace Business.Validators.Auth
{
	public class AuthRegisterDTOValidator : AbstractValidator<AuthRegisterDTO>
	{
		public AuthRegisterDTOValidator()
		{
			RuleFor(x => x.Email)
				.NotEmpty()
				.WithMessage("Poçt ünvanı daxil edilməlidir");

			RuleFor(x => x.Email)
				.EmailAddress()
				.WithMessage("Poçt ünvanı düzgün formatda deyil");

			RuleFor(x => x.Password.Length)
				.GreaterThanOrEqualTo(8)
				.WithMessage("Şifrənin uzunluğu minimum 8 simvol olmalıdır");

		}
	}
}

