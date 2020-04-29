﻿using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class SearchAddressRequest
    {
        public string Line1 { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
    }
}
