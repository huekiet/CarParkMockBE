//using CoreApp.dto.Request.Authentication;
//using CoreApp.dto.Response.Authentication;
using CoreApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Model.Entity;
using CoreApp.dto.Response.Authentication;
using CoreApp.dto.Request.Authentication;
using CoreApp.Model.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Linq;
using AutoMapper;
using CoreApp.dto.Dto;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using CoreApp.Model.Constant;

namespace CoreApp.Service.Implement
{
    public class AuthenticationService : IAuthenticationService
    {
        private IGenericRepository<Employee> _employeeRepository;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthenticationService(IGenericRepository<Employee> employeeRepository, IConfiguration configuration, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse(); ;
            var hasher = new PasswordHasher<Employee>();
            try
            {
                var employeeDb = _employeeRepository.FindByCondition(
                    item => item.Account == request.Username).FirstOrDefault();
                if (employeeDb != null)
                {
                    if (hasher.VerifyHashedPassword(null, employeeDb.Password, request.Password) == PasswordVerificationResult.Failed)
                    {
                        response.Errors = ERROR_RESPONSE.LOGIN_ERROR_RESPONSE;
                        return response;
                    }

                    response.Token = generateJwtToken(employeeDb);
                    response.Data = _mapper.Map<EmployeeDto>(employeeDb);
                    response.Success = true;
                } 
                else
                {
                    response.Errors = ERROR_RESPONSE.LOGIN_ERROR_RESPONSE;
                }
                return response;
            } catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return response;
            }
        }

        private string generateJwtToken(Employee employee)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, employee.EmployeeName),
               new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
               new Claim(ClaimTypes.Role, employee.Department)
            };

            var tokenKey = _configuration["TokenKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return tokenHandler.WriteToken(token);
        }

    }
}
