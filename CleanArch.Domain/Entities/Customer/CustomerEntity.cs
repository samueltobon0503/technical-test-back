namespace CleanArch.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public ICollection<Booking.BookingEntity> Bookings { get; set; }

    }
}
