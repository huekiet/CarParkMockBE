using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Car;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Car;
using CoreApp.Model.Constant;
using CoreApp.Model.Entity;
using CoreApp.Model.Repository.Interface;
using CoreApp.Model.Unit_of_Work;
using CoreApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(
            IGenericRepository<Car> carRepo, IGenericRepository<Ticket> ticketRepo,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._carRepository = carRepo;
            this._ticketRepository = ticketRepo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateCarRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<Car>(request);
                await _carRepository.Create(item);
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

        public async Task<BaseResponse> Delete(string id)
        {
            var response = new BaseResponse();
            try
            {
                var ticketCar = _ticketRepository.FindByCondition(item => item.LicensePlate == id).FirstOrDefault();
                if (ticketCar != null)
                {
                    response.Errors = ERROR_RESPONSE.DELETE_CAR_ERROR_RESPONSE;
                    return response;
                }
                await _carRepository.Delete(id);
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

        public async Task<PagingSearchCarResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchCarResponse();
            try
            {
                var items = _carRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "licenseplate":
                                items = items.Where(item => item.LicensePlate.Contains(search.FieldValue));
                                break;
                            case "cartype":
                                items = items.Where(item => item.CarType.Contains(search.FieldValue));
                                break;
                            case "carcolor":
                                items = items.Where(item => item.CarColor.Contains(search.FieldValue));
                                break;
                            case "company":
                                items = items.Where(item => item.Company.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                items = items.Include(item => item.Parkinglot);
                List<CarDto> result = _mapper.Map<List<CarDto>>(items);
                if (result.Any())
                {
                    response.TotalItems = result.Count;
                    response.TotalPages = (int)Math.Ceiling((decimal)response.TotalItems / request.PageSize);
                    response.Data = result.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).ToList();

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

        public async Task<CarDto> GetById(string id)
        {
            try
            {
                var data = _carRepository.GetDbSet().
                    Include(item => item.Parkinglot).
                    FirstOrDefault(item => item.LicensePlate == id);
                var response = _mapper.Map<CarDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateCarRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var carDb = await _carRepository.GetById(request.LicensePlate);
                carDb.ParkId = request.ParkId;
                carDb.CarColor = request.CarColor;
                carDb.CarType = request.CarType;
                carDb.Company = request.Company;

                await _carRepository.Update(carDb);
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
        public async Task<BaseResponse<List<CarDto>>> GetAll()
        {
            var response = new BaseResponse<List<CarDto>>();
            try
            {
                var cars = _carRepository.FindAll();
                response.Data = _mapper.Map<List<CarDto>>(cars.ToList());
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
