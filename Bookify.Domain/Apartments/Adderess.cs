using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Apartments;
public record Adderess
(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street
);
