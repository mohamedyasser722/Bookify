using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.RejectBooking;
public sealed record RejectBookingCommand(Guid BookingId) : ICommand;