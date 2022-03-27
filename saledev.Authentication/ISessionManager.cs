using System;
using System.Collections.Generic;

namespace saledev.Authentication;

public interface ISessionManager
{
    Guid GetUserId();
    List<string> GetRoles();
    void SaveClaim(string guid, List<string> roles);
}
