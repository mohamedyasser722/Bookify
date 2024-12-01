using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.CompleteBooking;
public sealed record CompleteBookingCommand(Guid BookingId) : ICommand;