using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BlogAPI.Filter
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof( AuthorizeActionFilter))
        {
        }

    }

    public class AuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            if(identity !=null)
            {
                var userClaims= identity.Claims;
                var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value !=null 
                    ?Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value) :0;

                if(userId == 0) {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        ReturnCode = System.Net.HttpStatusCode.Unauthorized,
                        ReturnMessage = "Vui lòng đăng nhập để thực hiện chức năng này "
                    });
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;

        }
    }
}
