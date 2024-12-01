using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.CancelBooking;
public record CancelBookingCommand(Guid BookingId) : ICommand;

