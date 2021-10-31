using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Employee;
using CoreApp.Model.Constant;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAPI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            this._employeeService = service;
        }

        [Authorize(Roles = "admin, employee")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateEmployeeRequest request)
        {
            return await _employeeService.Create(request);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpGet]
        public async Task<EmployeeDto> GetById(long id)
        {
            return await _employeeService.GetById(id);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _employeeService.Delete(id);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpPost]
        public async Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _employeeService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpPut] 
        public async Task<BaseResponse> Update(UpdateEmployeeRequest request)
        {
            return await _employeeService.Update(request);
        }
    }
}
