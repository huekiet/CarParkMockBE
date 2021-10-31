using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.BookingOffice;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Response;
using CoreApp.dto.Response.BookingOffice;
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
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookingOfficeController : ControllerBase
    {
        private readonly IBookingOfficeService _bookingOfficeService;
        public BookingOfficeController(IBookingOfficeService service)
        {
            this._bookingOfficeService = service;
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateBookingOfficeRequest request)
        {
            return await _bookingOfficeService.Create(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<BookingOfficeDto> GetById(long id)
        {
            return await _bookingOfficeService.GetById(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _bookingOfficeService.Delete(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<PagingSearchBookingOfficeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _bookingOfficeService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPut]
        public async Task<BaseResponse> Update(UpdateBookingOfficeRequest request)
        {
            return await _bookingOfficeService.Update(request);
        }
    }
}
