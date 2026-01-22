using AutoMapper;
using CleanArch.Application.Configuration;
using CleanArch.Application.DataBase.Booking.Commands.CreateBooking;
using CleanArch.Application.DataBase.Booking.Queries.GetAllBookings;
using CleanArch.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber;
using CleanArch.Application.DataBase.Booking.Queries.GetBookingsTypes;
using CleanArch.Application.DataBase.Customer.Commands.CreateCustomer;
using CleanArch.Application.DataBase.Customer.Commands.DeleteCustomer;
using CleanArch.Application.DataBase.Customer.Commands.UpdateCustomer;
using CleanArch.Application.DataBase.Customer.Queries.GetAllCustomer;
using CleanArch.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using CleanArch.Application.DataBase.Customer.Queries.GetCustomerById;
using CleanArch.Application.DataBase.User.Commands.CreateUser;
using CleanArch.Application.DataBase.User.Commands.DeleteUser;
using CleanArch.Application.DataBase.User.Commands.UpdateUser;
using CleanArch.Application.DataBase.User.Commands.UpdateUserPassword;
using CleanArch.Application.DataBase.User.Queries.GetAllUser;
using CleanArch.Application.DataBase.User.Queries.GetUserById;
using CleanArch.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using CleanArch.Application.Validators.Booking;
using CleanArch.Application.Validators.Customer;
using CleanArch.Application.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => 
            {
                config.AddProfile(new MapperProfile());
            });

            #region User
            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
            #endregion

            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>();
            services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();
            #endregion

            #region validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>(); 
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>(); 
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();

            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();

            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
            #endregion

            return services;
        }
    }
}
