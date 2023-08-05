using System;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Exceptions
{
	public class UnauthorizedException : Exception
	{
		public List<string> Errors { get; set; } = new List<string>();

		public UnauthorizedException(List<ValidationFailure> errors)
		{
            foreach (var error in errors)
                Errors.Add(error.ErrorMessage);
        }

		public UnauthorizedException(string error)
		{
			Errors.Add(error);
		}
	}
}

