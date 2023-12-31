﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Business.DTOs.Auth.Request;
using Business.DTOs.Auth.Response;
using Business.DTOs.Common;
using Business.Exceptions;
using Business.Services.Abstract;
using Business.Validators.Auth;
using Common.Entitties;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IMapper mapper,
                            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;
        }

       

        public async Task<Response> RegisterAsync(AuthRegisterDTO model)
        {
            var result = await new AuthRegisterDTOValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var user = await _userManager.FindByNameAsync(model.Email); //username de email saxladigimiz ucun
            if (user is not null)
                throw new ValidationException("Bu istifadeci artiq movcuddur");

            user = _mapper.Map<User>(model);

            var registerResult = await _userManager.CreateAsync(user , model.Password);
            if (!registerResult.Succeeded)
                throw new ValidationException(registerResult.Errors);

            var role = await _roleManager.FindByNameAsync("User");
            if (role is null)
                throw new NotFoundException("Role tapilmadi");

            var roleResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (!roleResult.Succeeded)
                throw new ValidationException(roleResult.Errors);

            return new Response
            {
                Message = "İstifadəçi uğurla yaradıldı"
            };
        }

        public async Task<Response<AuthLoginResponseDTO>> LoginAsync(AuthLoginDTO model)
        {
            var result = await new AuthLoginDTOValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user is null)
                throw new UnauthorizedException("Poçt ünvanı və ya şifrə yanlışdır");

            var isSucceededLoginCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if(!isSucceededLoginCheck)
                throw new UnauthorizedException("Poçt ünvanı və ya şifrə yanlışdır");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)  
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

            return new Response<AuthLoginResponseDTO>
            {
                Data = new AuthLoginResponseDTO
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            };
        }
    }
}

