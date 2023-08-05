﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DTOs.Auth.Request;
using Business.DTOs.Auth.Response;
using Business.DTOs.Common;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        #region Documentation
        /// <summary>
        /// İstifadəçinin Qeydiyyatdan keçməsi üçün 
        /// </summary>
        /// <param name="model"></param>
        #endregion
        [HttpPost("register")]
        public async Task<Response> RegisterAsync(AuthRegisterDTO model)
        {
            return await _authService.RegisterAsync(model);
        }


        #region Documentation
        /// <summary>
        /// İstifadəçilərin daxil olması üçün
        /// </summary>
        /// <param name="model"></param>
        #endregion
        [HttpPost("login")]
        public async Task<Response<AuthLoginResponseDTO>> LoginAsync(AuthLoginDTO model)
        {
            return await _authService.LoginAsync(model);
        }
    }
}

