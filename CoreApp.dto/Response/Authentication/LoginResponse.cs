using CoreApp.dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Response.Authentication
{
    public class LoginResponse: BaseResponse<EmployeeDto>
    {
        public string Token { get; set; }
    }

}
