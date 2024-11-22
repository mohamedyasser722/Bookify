using Bookify.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Email;
internal class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recepient, string sunject, string body)
    {
        return Task.CompletedTask;
    }
}
