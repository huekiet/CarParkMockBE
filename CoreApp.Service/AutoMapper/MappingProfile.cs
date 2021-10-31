using AutoMapper;
using CoreApp.dto.Dto;
using CoreApp.dto.Request.BookingOffice;
using CoreApp.dto.Request.Car;
using CoreApp.dto.Request.Employee;
using CoreApp.dto.Request.Parkinglot;
using CoreApp.dto.Request.Ticket;
using CoreApp.dto.Request.Trip;
using CoreApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Start Mapper Employee 
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Employee, CreateEmployeeRequest>();
            CreateMap<CreateEmployeeRequest, Employee>();
            // End Mapper Employee 

            // Start Mapper Car 
            CreateMap<Car, CarDto>().
                ForMember(des => des.ParkName, act => act.MapFrom(src => src.Parkinglot.ParkName));
            CreateMap<CarDto, Car>();

            CreateMap<Car, CreateCarRequest>();
            CreateMap<CreateCarRequest, Car>();
            // End Mapper Car 

            // Start Mapper Parkinglot 
            CreateMap<Parkinglot, ParkinglotDto>();
            CreateMap<ParkinglotDto, Parkinglot>();

            CreateMap<Parkinglot, CreateParkinglotRequest>();
            CreateMap<CreateParkinglotRequest, Parkinglot>();
            // End Mapper Parkinglot 

            // Start Mapper Ticket 
            CreateMap<Ticket, TicketDto>().
                ForMember(des => des.TripDestination, act => act.MapFrom(src => src.Trip.Destination));
            CreateMap<TicketDto, Ticket>();

            CreateMap<Ticket, CreateTicketRequest>();
            CreateMap<CreateTicketRequest, Ticket>();
            // End Mapper Ticket 

            // Start Mapper Trip 
            CreateMap<Trip, TripDto>();
            CreateMap<TripDto, Trip>();

            CreateMap<Trip, CreateTripRequest>();
            CreateMap<CreateTripRequest, Trip>();
            // End Mapper Trip 

            // Start Mapper BookingOffice 
            CreateMap<BookingOffice, BookingOfficeDto>().
                ForMember(des => des.TripDestination, act => act.MapFrom(src => src.Trip.Destination));
            CreateMap<BookingOfficeDto, BookingOffice>();

            CreateMap<BookingOffice, CreateBookingOfficeRequest>();
            CreateMap<CreateBookingOfficeRequest, BookingOffice>();
            // End Mapper BookingOffice 
        }
    }
}
