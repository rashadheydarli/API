using System;
namespace Business.DTOs.Common
{
	public class Response
	{
		public List<string> Errors { get; set; }
		public string Message { get; set; }
	}

	public class Response<T> : Response  //butun mehsullari gonderirik deye o da bir list seklinde getdiyi ucun bele bir class yaradiriq
	{
		public T Data { get; set; }
	}
}

