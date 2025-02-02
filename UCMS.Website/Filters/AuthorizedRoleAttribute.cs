using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UCMS.Website.Filters
{
    public class AuthorizedRoleAttribute : ActionFilterAttribute
    {
        private readonly string _role;

        public AuthorizedRoleAttribute(string role)
        {
            _role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the role from session
            var userRole = context.HttpContext.Session.GetString("Role").ToString();

            if (string.IsNullOrEmpty(userRole) || userRole != _role)
            {
                context.HttpContext.Session.Clear();

                // Redirect to login or unauthorized page if roles don't match
                context.Result = new RedirectToActionResult("Login", "Authentication", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
