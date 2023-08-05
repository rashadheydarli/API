using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Business.Exceptions
{
	public class ValidationException : Exception
	{
		public List<string> Errors { get; set; } = new List<string>();

		public ValidationException(List<ValidationFailure> errors)
		{
			foreach (var error in errors)
				Errors.Add(error.ErrorMessage);
			
		}
		public ValidationException(IEnumerable<IdentityError> errors)
		{
			foreach (var error in errors)
                Errors.Add(error.Description);
        }

		public ValidationException(string error)
		{
			Errors.Add(error);
		}

	}
}

