namespace CleanArch.Application.DataBase.Booking.Queries.GetBookingsTypes
{
    public interface IGetBookingsByTypeQuery
    {
        Task<List<GetBookingsByTypeModel>> Execute(string type);
    }
}
