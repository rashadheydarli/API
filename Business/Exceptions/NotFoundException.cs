using System;
using FluentValidation.Results;

namespace Business.Exceptions
{
	public class NotFoundException : Exception
	{
        public List<string> Errors { get; set; } = new List<string>();

        public NotFoundException(string error)
        {
               Errors.Add(error);
        }
    }
}

