using System;
using Business.DTOs.Product.Request;
using FluentValidation;

namespace Business.Validators.Product
{
	public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
	{
		public ProductCreateDTOValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty()
				.WithMessage("Basliq daxil edilmelidir");

			RuleFor(x => x.Title)
				.MinimumLength(10)
				.WithMessage("Basligin uzunlugu minimum 10 simvol olmalidir");

			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("Açıqlama daxil edilməlidir");

			RuleFor(x => x.Description)
				.MaximumLength(500)
				.WithMessage("Açıqlamanın uzunluğu maksimum 500 simvol olmalıdır");

			RuleFor(x => x.Price)
				.NotEmpty()
				.WithMessage("Məbləğ daxil edilməlidir");

			RuleFor(x => x.Quantity)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Say düzgün daxil edilməyib");

			RuleFor(x => x.Photo)
				.Must(IsBase64String)
				.WithMessage("Göndərilən şəkil contenti düzgün formatda deyil");

            RuleFor(x => x.Type)
                 .IsInEnum()
                 .WithMessage("Tip duzgun secilmeyib");

        }

		private static bool IsBase64String(string photo)
		{
            byte[] output;
            try
			{
				output = Convert.FromBase64String(photo);
				return true;
			}
			catch (FormatException e)
			{
				return false;
			}
		}
	}
}

