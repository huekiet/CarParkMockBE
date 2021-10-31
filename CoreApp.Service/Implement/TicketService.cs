using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request;
using CoreApp.dto.Request.Ticket;
using CoreApp.dto.Response;
using CoreApp.dto.Response.Ticket;
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
    public class TicketService : ITicketService
    {
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IGenericRepository<Ticket> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._ticketRepository = repo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Create(CreateTicketRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var item = _mapper.Map<Ticket>(request);
                await _ticketRepository.Create(item);
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
                await _ticketRepository.Delete(id);
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

        public async Task<PagingSearchTicketResponse> GetByPagingAndFilter(BasePagingSearchRequest request)
        {
            var response = new PagingSearchTicketResponse();
            try
            {
                var items = _ticketRepository.FindAll();

                if (request.Filter != null)
                {
                    foreach (SearchDto search in request.Filter)
                    {
                        switch (search.Field.ToLower())
                        {
                            case "licenseplate":
                                items = items.Where(item => item.LicensePlate.Contains(search.FieldValue));
                                break;
                            case "customername":
                                items = items.Where(item => item.CustomerName.Contains(search.FieldValue));
                                break;
                        }
                    }
                }

                items = items.Include(item => item.Trip);

                List<TicketDto> result = _mapper.Map<List<TicketDto>>(items);
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

        public async Task<TicketDto> GetById(long id)
        {
            try
            {
                var data = _ticketRepository.GetDbSet().
                    Include(item => item.Trip).
                    FirstOrDefault(item => item.TicketId == id); 
                var response = _mapper.Map<TicketDto>(data);
                return await Task.FromResult(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }
        }

        public async Task<BaseResponse> Update(UpdateTicketRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var ticketDb = await _ticketRepository.GetById(request.TicketId);
                ticketDb.BookingTime = request.BookingTime;
                ticketDb.CustomerName = request.CustomerName;
                ticketDb.LicensePlate = request.LicensePlate;
                ticketDb.TripId = request.TripId;

                await _ticketRepository.Update(ticketDb);
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
