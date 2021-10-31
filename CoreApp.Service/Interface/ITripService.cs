using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Trip;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Parkinglot;
using CoreApp.dto.Response.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface ITripService
    {
        public Task<BaseResponse> Create(CreateTripRequest request);

        public Task<BaseResponse> Update(UpdateTripRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<TripDto> GetById(long id);

        public Task<PagingSearchTripResponse> GetByPagingAndFilter(BasePagingSearchRequest request);

        public Task<BaseResponse<List<TripDto>>> GetAll();

    }
}
