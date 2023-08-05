using System;
using AutoMapper;
using Business.DTOs.Role.Request;
using Business.DTOs.Role.Response;
using Microsoft.AspNetCore.Identity;

namespace Business.MappingProfiles
{
	public class RoleMappingProfile : Profile
	{
		public RoleMappingProfile()
		{
			CreateMap<RoleCreateDTO, IdentityRole>();
			CreateMap<IdentityRole, RoleDTO>();
		}
	}
}

