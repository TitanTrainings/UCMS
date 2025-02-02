using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UCMS.Website.Filters
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(session))
            {
                // Redirect to Login page if session is empty
                context.Result = new RedirectToActionResult("Login", "Authentication", null);
            }
            base.OnActionExecuting(context);
        }
    }    
}
