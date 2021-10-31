using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Request.Trip;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Trip;
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
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public TripController(ITripService service)
        {
            this._tripService = service;
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateTripRequest request)
        {
            return await _tripService.Create(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<TripDto> GetById(long id)
        {
            return await _tripService.GetById(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _tripService.Delete(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<PagingSearchTripResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _tripService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPut]
        public async Task<BaseResponse> Update(UpdateTripRequest request)
        {
            return await _tripService.Update(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<BaseResponse<List<TripDto>>> GetAll()
        {
            return await _tripService.GetAll();
        }
    }
}
