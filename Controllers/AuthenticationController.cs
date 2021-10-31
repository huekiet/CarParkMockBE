using CoreApp.Data.Entity;
using CoreApp.dto.Request.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Service.Interface;

namespace CarParkProject.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        // GET: AuthenticationController/Create
        [HttpGet]
        public ActionResult GetFirstEmployee()
        {
            return Ok("OK baby");
        }

        // POST: AuthenticationController/Create
        [HttpPost]
        public async Task<employee> Login(LoginRequest request)
        {
            var data = await authenticationService.Login2(request);
            return data;
        }

    }
}
