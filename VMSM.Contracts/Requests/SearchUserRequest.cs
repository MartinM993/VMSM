﻿using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class SearchUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
    }
}
