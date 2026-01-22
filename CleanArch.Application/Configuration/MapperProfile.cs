using AutoMapper;
using CleanArch.Application.DataBase.Booking.Commands.CreateBooking;
using CleanArch.Application.DataBase.Booking.Queries.GetAllBookings;
using CleanArch.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber;
using CleanArch.Application.DataBase.Booking.Queries.GetBookingsTypes;
using CleanArch.Application.DataBase.Customer.Commands.CreateCustomer;
using CleanArch.Application.DataBase.Customer.Commands.UpdateCustomer;
using CleanArch.Application.DataBase.Customer.Queries.GetAllCustomer;
using CleanArch.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using CleanArch.Application.DataBase.Customer.Queries.GetCustomerById;
using CleanArch.Application.DataBase.User.Commands.CreateUser;
using CleanArch.Application.DataBase.User.Commands.UpdateUser;
using CleanArch.Application.DataBase.User.Queries.GetAllUser;
using CleanArch.Application.DataBase.User.Queries.GetUserById;
using CleanArch.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using CleanArch.Domain.Entities.Booking;
using CleanArch.Domain.Entities.Customer;
using CleanArch.Domain.Entities.User;

namespace CleanArch.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            CreateMap<BookingEntity, GetAllBookingsModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingsByDocumentNumberModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingsByTypeModel>().ReverseMap();
            #endregion

        }
    }
}
