using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Parkinglot;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Parkinglot;
using CoreApp.Model.Constant;
using CoreApp.Model.Entity;
using CoreApp.Model.Repository.Interface;
using CoreApp.Model.Unit_of_Work;
using CoreApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class ParkinglotService : IParkinglotService
    {
        private readonly IGenericRepository<Parkinglot> _parkinglotRepository;
        private readonly IGenericRepository<Car> _carRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ParkinglotService(IGenericRepository<Parkinglot> parkRepo, IGenericRepository<Car> carRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._parkinglotRepository = parkRepo;
            this._carRepository = carRepo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateParkinglotRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<Parkinglot>(request);
                await _parkinglotRepository.Create(item);
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
                var carInParkinglot = _carRepository.FindByCondition(item => item.ParkId == id).FirstOrDefault();
                if (carInParkinglot != null)
                {
                    response.Errors = ERROR_RESPONSE.DELETE_PARKINGLOT_ERROR_RESPONSE;
                    return response;
                }
                await _parkinglotRepository.Delete(id);
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

        public async Task<PagingSearchParkinglotResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchParkinglotResponse();
            try
            {
                var items = _parkinglotRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "parkarea":
                                items = items.Where(item => item.ParkArea.ToString().Contains(search.FieldValue));
                                break;
                            case "parkname":
                                items = items.Where(item => item.ParkName.Contains(search.FieldValue));
                                break;
                            case "parkplace":
                                items = items.Where(item => item.ParkPlace.Contains(search.FieldValue));
                                break;
                            case "parkprice":
                                items = items.Where(item => item.ParkPrice.ToString().Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                List<ParkinglotDto> result = _mapper.Map<List<ParkinglotDto>>(items);
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

        public async Task<ParkinglotDto> GetById(long id)
        {
            try
            {
                var data = await _parkinglotRepository.GetById(id);
                var response = _mapper.Map<ParkinglotDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateParkinglotRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var parkinglotDb = await _parkinglotRepository.GetById(request.ParkId);
                parkinglotDb.ParkArea = request.ParkArea;
                parkinglotDb.ParkName = request.ParkName;
                parkinglotDb.ParkPlace = request.ParkPlace;
                parkinglotDb.ParkPrice= request.ParkPrice;
                parkinglotDb.ParkStatus = request.ParkStatus;

                await _parkinglotRepository.Update(parkinglotDb);
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

        public async Task<BaseResponse<List<ParkinglotDto>>> GetAll()
        {
            var response = new BaseResponse<List<ParkinglotDto>>();
            try
            {
                var parkinglots = _parkinglotRepository.FindAll();
                response.Data = _mapper.Map<List<ParkinglotDto>>(parkinglots.ToList());
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
