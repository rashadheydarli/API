using System;
using Business.DTOs.Role.Request;
using FluentValidation;

namespace Business.Validators.Role
{
	public class RoleCreateDTOValidator : AbstractValidator<RoleCreateDTO>
	{
		public RoleCreateDTOValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Ad daxil edilməlidir");
		}
	}
}

