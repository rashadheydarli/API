using System;
using Business.DTOs.Auth.Request;
using Business.DTOs.Auth.Response;
using Business.DTOs.Common;

namespace Business.Services.Abstract
{
	public interface IAuthService
	{
		Task<Response> RegisterAsync(AuthRegisterDTO model);
		Task<Response<AuthLoginResponseDTO>> LoginAsync(AuthLoginDTO model);
	}
}

