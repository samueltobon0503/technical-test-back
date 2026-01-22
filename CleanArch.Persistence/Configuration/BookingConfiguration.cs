using CleanArch.Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder) 
        {
            entityBuilder.HasKey(x => x.BookingId);
            entityBuilder.Property(x => x.RegisterDate).IsRequired();
            entityBuilder.Property(x => x.Code).IsRequired();
            entityBuilder.Property(x => x.Type).IsRequired();

            entityBuilder.HasOne(x => x.user)
                         .WithMany(x => x.Bookings)
                         .HasForeignKey(x => x.UserId);
            entityBuilder.HasOne(x => x.Customer)
                        .WithMany(x => x.Bookings)
                        .HasForeignKey(x => x.CustomerId);
        }
    }
}
