using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace saledev.Authentication.JwtBearer
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationOptions options;

        public AuthenticationService(IOptions<AuthenticationOptions> options)
        {
            this.options = options.Value;
        }

        public string EncodeClaim(Claim claim)
        {
            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(options.Secret)
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(options.HoursTokenIsValid).ToUnixTimeSeconds())
                      .AddClaim("UserId", claim.UserId)
                      .AddClaim("Roles", claim.Roles)
                      .Encode();
            return token;
        }

        public Claim DecodeClaim(string token)
        {
            try
            {
                var payload = JwtBuilder.Create()
                            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                            .WithSecret(options.Secret)
                            .MustVerifySignature()
                            .Decode<IDictionary<string, object>>(token);

                var claim = new Claim()
                {
                    UserId = (string)payload["UserId"],
                    Roles = ((Newtonsoft.Json.Linq.JArray) payload["Roles"]).ToObject<List<string>>()
                };
                return claim;
            }
            catch (InvalidCastException ex)
            {
                return new Claim() { ErrorMessage = "InvalidCastException: " + ex.Message };
            }
            catch (TokenExpiredException)
            {
                return new Claim() { ErrorMessage = "Token expired." };
            }
            catch (SignatureVerificationException)
            {
                return new Claim() { ErrorMessage = "Verification failed." };
            }
        }
    }
}
