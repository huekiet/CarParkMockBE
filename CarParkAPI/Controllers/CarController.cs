using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Car;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Car;
using CoreApp.Service.Interface;
using CoreApp.Service.Interfaces;
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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService service)
        {
            this._carService = service;
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateCarRequest request)
        {
            return await _carService.Create(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<CarDto> GetById(string id)
        {
            return await _carService.GetById(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(string id)
        {
            return await _carService.Delete(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<PagingSearchCarResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _carService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPut]
        public async Task<BaseResponse> Update(UpdateCarRequest request)
        {
            return await _carService.Update(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<BaseResponse<List<CarDto>>> GetAll()
        {
            return await _carService.GetAll();
        }
    }
}
