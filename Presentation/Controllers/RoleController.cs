using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.DTOs.Common;
using Business.DTOs.Role.Request;
using Business.DTOs.Role.Response;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #region Documentation
        /// <summary>
        /// Rolların Siyahısı
        /// </summary>
        #endregion  
        [HttpGet]
        public async Task<Response<List<RoleDTO>>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }

        #region Documentation
        /// <summary>
        /// Rol yaratmaq üçün
        /// </summary>
        /// <param name="model"></param>
        #endregion  
        [HttpPost]
        public async Task<Response> CreateAsync(RoleCreateDTO model)
        {
           return await  _roleService.CreateAsync(model);
        }
    }
}

