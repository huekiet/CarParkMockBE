using CoreApp.dto.Request.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Service.Interface;
using System.Diagnostics;
using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CarParkProject.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
        {
            this._authenticationService = authenticationService;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            return await _authenticationService.Login(request).ConfigureAwait(false);
        }

    }
}
