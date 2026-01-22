using CleanArch.Domain.Entities.Booking;
using CleanArch.Domain.Entities.Customer;
using CleanArch.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<BookingEntity> Booking {  get; set; }

        Task<bool> SaveAsync();
    }
}
