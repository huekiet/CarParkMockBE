using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Trip;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Trip;
using CoreApp.Model.Constant;
using CoreApp.Model.Entity;
using CoreApp.Model.Repository.Interface;
using CoreApp.Model.Unit_of_Work;
using CoreApp.Service.Interface;
using CoreApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Service.Implement
{
    public class TripService : ITripService
    {
        private readonly IGenericRepository<Trip> _tripRepository;
        private readonly IGenericRepository<BookingOffice> _bookingOfficeRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TripService(
            IGenericRepository<Trip> tripRepo, IGenericRepository<BookingOffice> officeRepo,
            IGenericRepository<Ticket> ticketRepo,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._tripRepository = tripRepo;
            this._bookingOfficeRepository = officeRepo;
            this._ticketRepository = ticketRepo;

            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateTripRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<Trip>(request);
                await _tripRepository.Create(item);
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
                var tripTicket = _ticketRepository.FindByCondition(item => item.TripId == id).FirstOrDefault();
                if (tripTicket != null)
                {
                    response.Errors = ERROR_RESPONSE.DELETE_TRIP_TICKET_ERROR_RESPONSE;
                    return response;
                }

                var tripOffice = _bookingOfficeRepository.FindByCondition(item => item.OfficeId == id).FirstOrDefault();
                if (tripOffice != null)
                {
                    response.Errors = ERROR_RESPONSE.DELETE_TRIP_BOOKING_OFFICE_ERROR_RESPONSE;
                    return response;
                }

                await _tripRepository.Delete(id);
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

        public async Task<PagingSearchTripResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchTripResponse();
            try
            {
                var items = _tripRepository.FindAll();

                List<TripDto> result = _mapper.Map<List<TripDto>>(items);
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

        public async Task<TripDto> GetById(long id)
        {
            try
            {
                var data = await _tripRepository.GetById(id);
                var response = _mapper.Map<TripDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateTripRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var tripDb = await _tripRepository.GetById(request.TripId);
                tripDb.BookedTicketNumber = request.BookedTicketNumber;
                tripDb.CarType = request.CarType;
                tripDb.DepartureDate = request.DepartureDate;
                tripDb.DepartureTime = request.DepartureTime;
                tripDb.Destination = request.Destination;
                tripDb.Driver = request.Driver;
                tripDb.MaximumOnlineTicketNumber = request.MaximumOnlineTicketNumber;

                await _tripRepository.Update(tripDb);
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

        public async Task<BaseResponse<List<TripDto>>> GetAll()
        {
            var response = new BaseResponse<List<TripDto>>();
            try
            {
                var trips = _tripRepository.FindAll();
                response.Data = _mapper.Map<List<TripDto>>(trips.ToList());
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
