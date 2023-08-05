using System;
using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.Role.Request;
using Business.DTOs.Role.Response;
using Business.Exceptions;
using Business.Services.Abstract;
using Business.Validators.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Concrete
{
	public class RoleService : IRoleService
	{
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<IdentityRole> roleManager,
                            IMapper mapper)
		{
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<Response<List<RoleDTO>>> GetAllAsync()
        {
            return new Response<List<RoleDTO>>
            {
                Data = _mapper.Map<List<RoleDTO>>(await _roleManager.Roles.ToListAsync())
            };
        }


        public async Task<Response> CreateAsync(RoleCreateDTO model)
        {
            var result = await new RoleCreateDTOValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var role = _roleManager.FindByNameAsync(model.Name);
            if (role is not null)
                throw new ValidationException("Bu adda rol artiq movcuddur");

            var roleResult = await _roleManager.CreateAsync(_mapper.Map<IdentityRole>(model));
            if (!roleResult.Succeeded)
                throw new ValidationException(roleResult.Errors);

            return new Response
            {
                Message = "Rol ugurla yaradildi"
            };
        }

        
    }
}

