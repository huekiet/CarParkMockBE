using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Request.Parkinglot;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Parkinglot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interfaces
{
    public interface IParkinglotService
    {
        public Task<BaseResponse> Create(CreateParkinglotRequest request);

        public Task<BaseResponse> Update(UpdateParkinglotRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<ParkinglotDto> GetById(long id);

        public Task<PagingSearchParkinglotResponse> GetByPagingAndFilter(BasePagingSearchRequest request);

        public Task<BaseResponse<List<ParkinglotDto>>> GetAll();

    }
}
