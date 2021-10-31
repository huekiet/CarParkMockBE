using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Ticket;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Ticket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interfaces
{
    public interface ITicketService
    {
        public Task<BaseResponse> Create(CreateTicketRequest request);

        public Task<BaseResponse> Update(UpdateTicketRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<TicketDto> GetById(long id);

        public Task<PagingSearchTicketResponse> GetByPagingAndFilter(BasePagingSearchRequest request);

    }
}
