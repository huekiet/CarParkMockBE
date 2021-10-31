using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Request.Parkinglot;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Parkinglot;
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
    public class ParkinglotController : ControllerBase
    {
        private readonly IParkinglotService _parkinglotService;
        public ParkinglotController(IParkinglotService service)
        {
            this._parkinglotService = service;
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateParkinglotRequest request)
        {
            return await _parkinglotService.Create(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<ParkinglotDto> GetById(long id)
        {
            return await _parkinglotService.GetById(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _parkinglotService.Delete(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<PagingSearchParkinglotResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _parkinglotService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPut]
        public async Task<BaseResponse> Update(UpdateParkinglotRequest request)
        {
            return await _parkinglotService.Update(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<BaseResponse<List<ParkinglotDto>>> GetAll()
        {
            return await _parkinglotService.GetAll();
        }
    }
}
