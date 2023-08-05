using System;
using Business.DTOs.Common;
using Business.DTOs.Role.Request;
using Business.DTOs.Role.Response;

namespace Business.Services.Abstract
{
	public interface IRoleService
	{
		Task<Response<List<RoleDTO>>> GetAllAsync();
		Task<Response> CreateAsync(RoleCreateDTO model);
	}
}

