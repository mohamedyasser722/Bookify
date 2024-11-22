using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories;
internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses = new[]
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    private readonly ApplicationDbContext _dbcontext;
    public BookingRepository(ApplicationDbContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
    {
        return await _dbcontext.Bookings
            .AnyAsync(booking => 
            booking.ApartmentId == apartment.Id &&
            booking.Duration.OverlapsWith(duration) &&
            ActiveBookingStatuses.Contains(booking.Status)
            , cancellationToken);

    }
}
