using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Request.Ticket;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Ticket;
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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService service)
        {
            this._ticketService = service;
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<BaseResponse> Create([FromBody] CreateTicketRequest request)
        {
            return await _ticketService.Create(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpGet]
        public async Task<TicketDto> GetById(long id)
        {
            return await _ticketService.GetById(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpDelete]
        public async Task<BaseResponse> Delete(long id)
        {
            return await _ticketService.Delete(id);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPost]
        public async Task<PagingSearchTicketResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            return await _ticketService.GetByPagingAndFilter(request);
        }

        [Authorize(Roles = "admin, parking")]
        [HttpPut]
        public async Task<BaseResponse> Update(UpdateTicketRequest request)
        {
            return await _ticketService.Update(request);
        }
    }
}
