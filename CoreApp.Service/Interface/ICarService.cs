using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Car;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Car;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interfaces
{
    public interface ICarService
    {
        public Task<BaseResponse> Create(CreateCarRequest request);

        public Task<BaseResponse> Update(UpdateCarRequest request);

        public Task<BaseResponse> Delete(string id);

        public Task<CarDto> GetById(string id);

        public Task<PagingSearchCarResponse> GetByPagingAndFilter(BasePagingSearchRequest request);

        public Task<BaseResponse<List<CarDto>>> GetAll();

    }
}
