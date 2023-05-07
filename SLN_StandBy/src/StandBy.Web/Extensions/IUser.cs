using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StandBy.Web.Extensions
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool isAuthenticated();
        bool hasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();


    }
}