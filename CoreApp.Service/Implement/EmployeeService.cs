using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Employee;
using CoreApp.Model.Entity;
using CoreApp.Model.Repository.Interface;
using CoreApp.Model.Unit_of_Work;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IGenericRepository<Employee> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._employeeRepository = repo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateEmployeeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var hasher = new PasswordHasher<Employee>();
                var item = _mapper.Map<Employee>(request);
                item.Password = hasher.HashPassword(null, item.Password);
                await _employeeRepository.Create(item);
                _unitOfWork.Commit();
                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }

        public async Task<BaseResponse> Delete(long id)
        {
            var response = new BaseResponse();
            try
            {
                await _employeeRepository.Delete(id);
                _unitOfWork.Commit();
                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }

        public async Task<PagingSearchEmployeeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchEmployeeResponse();
            try
            {
                var items = _employeeRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "employeename":
                            case "name":
                                items = items.Where(item => item.EmployeeName.Contains(search.FieldValue));
                                break;
                            case "account":
                                items = items.Where(item => item.Account.Contains(search.FieldValue));
                                break;
                            case "address":
                                items = items.Where(item => item.EmployeeAddress.Contains(search.FieldValue));
                                break;
                            case "phonenumber":
                                items = items.Where(item => item.EmployeePhone.Contains(search.FieldValue));
                                break;
                            case "department":
                                items = items.Where(item => item.Department.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                List<EmployeeDto> result = _mapper.Map<List<EmployeeDto>>(items);
                if (result.Any())
                {
                    response.TotalItems = result.Count;
                    response.TotalPages = (int)Math.Ceiling((decimal)response.TotalItems / request.PageSize);
                    response.Data = result.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).ToList();
                    response.PageSize = request.PageSize;
                    response.PageIndex = request.PageIndex;
                }

                response.Success = true;
                return await Task.FromResult(response).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }

        public async Task<EmployeeDto> GetById(long id)
        {
            try
            {
                var data = await _employeeRepository.GetById(id);
                var response = _mapper.Map<EmployeeDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateEmployeeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var hasher = new PasswordHasher<Employee>();
                var employeeDb = await _employeeRepository.GetById(request.Id);
                employeeDb.EmployeeAddress = request.EmployeeAddress;
                employeeDb.EmployeeName = request.EmployeeName;
                employeeDb.EmployeePhone = request.EmployeePhone;
                employeeDb.EmployeeBirthdate = request.EmployeeBirthdate;
                employeeDb.EmployeeEmail = request.EmployeeEmail;
                employeeDb.Department = request.Department;
                employeeDb.Sex = request.Sex;
                employeeDb.Password = hasher.HashPassword(null, request.Password);
                await _employeeRepository.Update(employeeDb);
                _unitOfWork.Commit();
                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return response;
            }
        }
    }
}
