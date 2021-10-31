using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.BookingOffice;
using CoreApp.dto.Response;
using CoreApp.dto.Response.BookingOffice;
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
    public class BookingOfficeService: IBookingOfficeService
    {
        private readonly IGenericRepository<BookingOffice> _bookingOfficeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookingOfficeService(IGenericRepository<BookingOffice> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._bookingOfficeRepository = repo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateBookingOfficeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<BookingOffice>(request);
                await _bookingOfficeRepository.Create(item);
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
                await _bookingOfficeRepository.Delete(id);
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

        public async Task<PagingSearchBookingOfficeResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchBookingOfficeResponse();
            try
            {
                var items = _bookingOfficeRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "employeename":
                            case "name":
                                items = items.Where(item => item.OfficeName.Contains(search.FieldValue));
                                break;
                            case "phone":
                                items = items.Where(item => item.OfficePhone.Contains(search.FieldValue));
                                break;
                            case "place":
                                items = items.Where(item => item.OfficePlace.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                items = items.Include(item => item.Trip);
                List<BookingOfficeDto> result = _mapper.Map<List<BookingOfficeDto>>(items);
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

        public async Task<BookingOfficeDto> GetById(long id)
        {
            try
            {
                var data = _bookingOfficeRepository.GetDbSet().
                    Include(item => item.Trip).
                    FirstOrDefault(item => item.OfficeId == id);
                var response = _mapper.Map<BookingOfficeDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateBookingOfficeRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var bookingOfficeDb = await _bookingOfficeRepository.GetById(request.OfficeId);
                bookingOfficeDb.OfficeName = request.OfficeName;
                bookingOfficeDb.OfficePhone = request.OfficePhone;
                bookingOfficeDb.OfficePlace = request.OfficePlace;
                bookingOfficeDb.OfficePrice= request.OfficePrice;

                await _bookingOfficeRepository.Update(bookingOfficeDb);
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
