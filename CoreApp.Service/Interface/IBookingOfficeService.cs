using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.BookingOffice;
using CoreApp.dto.Response;
using CoreApp.dto.Response.BookingOffice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interfaces
{
    public interface IBookingOfficeService
    {
        public Task<BaseResponse> Create(CreateBookingOfficeRequest request);

        public Task<BaseResponse> Update(UpdateBookingOfficeRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<BookingOfficeDto> GetById(long id);

        public Task<PagingSearchBookingOfficeResponse> GetByPagingAndFilter(BasePagingSearchRequest request);
    }
}
