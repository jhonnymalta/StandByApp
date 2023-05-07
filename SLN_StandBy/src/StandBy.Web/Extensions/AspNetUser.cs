using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StandBy.Web.Extensions
{
    public class AspNetUser : IUser
    {


        private readonly IHttpContextAccessor _acessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _acessor = accessor;
        }

        public string Name => _acessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaims()
        {
            return _acessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _acessor.HttpContext;
        }

        public string GetUserEmail()
        {
            return isAuthenticated() ? _acessor.HttpContext.User.GetUserEmail() : "";
        }

        public Guid GetUserId()
        {
            return isAuthenticated() ? Guid.Parse(_acessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserToken()
        {
            return isAuthenticated() ? _acessor.HttpContext.User.GetUserToken() : "";
        }

        public bool hasRole(string role)
        {
            return _acessor.HttpContext.User.IsInRole(role);
        }

        public bool isAuthenticated()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }

    public static class ClaimsPrincipalExtensins
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("sub");
            return claim?.Value;

        }


        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("email");
            return claim?.Value;
        }



        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("JWT");
            return claim?.Value;

        }
    }
}