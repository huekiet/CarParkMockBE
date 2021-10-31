using CoreApp.dto.Request.Authentication;
using CoreApp.dto.Response.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest request);

    }
}
