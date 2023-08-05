using System;
using AutoMapper;
using Business.DTOs.Auth.Request;
using Common.Entitties;

namespace Business.MappingProfiles
{
	public class AuthMappingProfile : Profile
	{
		public AuthMappingProfile()
		{
			CreateMap<AuthRegisterDTO, User>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

			//userin Username sourcenin Email prop beraber olacaq
			//propertylerinde ferq var username yoxdur AuthRegisterDtO da amma userde var
		}
	}
}

