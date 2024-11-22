﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments.SearchApartments;
public sealed class AddressResponse
{
    public string Country { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string Street { get; init; }
}