﻿using System.Collections.Generic;

namespace saledev.Authentication
{
    public class Claim
    {
        public string UserId { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Rights { get; set; } = new List<string>();
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
