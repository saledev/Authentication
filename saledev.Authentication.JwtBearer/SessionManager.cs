using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace saledev.Authentication.JwtBearer;

public class SessionManager : ISessionManager
{
    private Guid? UserId;
    private List<string>? Roles;
    private List<string>? Rights;

    private readonly IStringLocalizer<SessionManager> localizer;

    public SessionManager(IStringLocalizer<SessionManager> localizer)
    {
        this.localizer = localizer;
    }

    public Guid GetUserId()
    {
        if (UserId == null)
        {
            throw new ArgumentNullException(localizer["{0} not found in session.", nameof(UserId)]);
        }

        return UserId.Value;
    }

    public Guid? TryGetUserId()
    {
        return UserId;
    }

    public List<string> GetRoles()
    {
        if (Roles == null)
        {
            throw new ArgumentNullException(localizer["{0} not found in session.", nameof(Roles)]);
        }

        return Roles;
    }

    public List<string>? TryGetRoles()
    {
        return Roles;
    }

    public List<string> GetRights()
    {
        if (Rights == null)
        {
            throw new ArgumentNullException(localizer["{0} not found in session.", nameof(Rights)]);
        }

        return Rights;
    }

    public List<string>? TryGetRights()
    {
        return Rights;
    }

    public void SaveClaim(string guid, List<string> roles, List<string> rights)
    {
        UserId = Guid.Parse(guid);
        Roles = roles;
        Rights = rights;
    }
}
