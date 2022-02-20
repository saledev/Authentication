using System;

namespace saledev.Authentication.JwtBearer
{
    public class AuthenticationOptions
    {
        public const string SectionName = "Authentication";

        public string Secret { get; set; } = String.Empty;
        public int HoursTokenIsValid { get; set; } = 1;
    }
}