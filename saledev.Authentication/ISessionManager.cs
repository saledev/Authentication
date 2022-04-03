using System;
using System.Collections.Generic;

namespace saledev.Authentication;

public interface ISessionManager
{
    Guid GetUserId();
    Guid? TryGetUserId();
    List<string> GetRoles();
    void SaveClaim(string guid, List<string> roles, List<string> rights);
    List<string>? TryGetRoles();
    List<string> GetRights();
    List<string>? TryGetRights();
}
