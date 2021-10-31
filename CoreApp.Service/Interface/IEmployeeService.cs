using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<BaseResponse> Create(CreateEmployeeRequest request);

        public Task<BaseResponse> Update(UpdateEmployeeRequest request);

        public Task<BaseResponse> Delete(long id);

        public Task<EmployeeDto> GetById(long id);

        public Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request);

    }
}
