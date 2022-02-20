namespace saledev.Authentication
{
    public interface IAuthenticationService
    {
        string EncodeClaim(Claim claim);
        Claim DecodeClaim(string token);
    }
}
