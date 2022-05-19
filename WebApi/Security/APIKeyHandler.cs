using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApi.Data_Access_Later;

namespace WebApi.Security
{
    public class APIKeyHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"];
            AdminDAL adminDAL = new AdminDAL();
            var admin = adminDAL.GetAdminByApiKey(apiKey);
            if (admin != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(admin.username, "APIKey"));
                HttpContext.Current.User = principal;
            }
            else
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}